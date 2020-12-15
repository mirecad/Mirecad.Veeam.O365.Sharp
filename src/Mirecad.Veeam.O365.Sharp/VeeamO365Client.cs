using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using AutoMapper.Mappers;
using Mirecad.Veeam.O365.Sharp.Clients;
using Mirecad.Veeam.O365.Sharp.Handlers;
using Mirecad.Veeam.O365.Sharp.Helpers;
using Mirecad.Veeam.O365.Sharp.Infrastructure;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;

namespace Mirecad.Veeam.O365.Sharp
{
    public class VeeamO365Client : RestClient, IDisposable, IVeeamO365Client
    {
        private const string ApiVersion = "5";

        private Uri _baseAddress;
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IDataTransferObjectResolver _dtoResolver;

        public IBackupRepositoryClient BackupRepositories { get; private set; }
        public IJobClient Jobs { get; private set; }
        public IMailboxClient Mailboxes { get; private set; }
        public IOneDriveClient OneDrives { get; private set; }
        public IOrganizationClient Organizations { get; private set; }
        public IOrganizationUserClient OrganizationUsers { get; private set; }
        public IOrganizationSiteClient OrganizationSites { get; private set; }
        public IOrganizationGroupClient OrganizationGroups { get; private set; }
        public ISharePointClient SharePoints { get; private set; }
        public IRestoreSessionClient RestoreSessions { get; private set; }
        public ILicensedUserClient LicensedUsers { get; private set; }

        protected VeeamO365Client(HttpClient client, Uri baseAddress, IDataTransferObjectResolver dtoResolver) : base(client)
        {
            var serviceContainer = DiContainer.Create(this, dtoResolver);
            var mapper = Mapping.Create(dtoResolver, serviceContainer);

            Setup(client, baseAddress, dtoResolver, mapper);
        }

        protected VeeamO365Client(HttpClient client, Uri baseAddress, IDataTransferObjectResolver dtoResolver, IMapper mapper) : base(client)
        {
            Setup(client, baseAddress, dtoResolver, mapper);
        }

        public static VeeamO365Client CreateAuthenticatedClient(VeeamO365ClientOptions options)
        {
            var handler = new OAuthLoginHandler($"{options.BaseAddress}v{ApiVersion}/token", options.Username, options.Password);
            var client = new HttpClient(handler)
            {
                BaseAddress = options.BaseAddress,
                Timeout = options.HttpTimeout
            };
            var dtoResolver = new DataTransferObjectResolver();
            return new VeeamO365Client(client, options.BaseAddress, dtoResolver);
        }

        /// <summary>
        /// Retrieves expected domain object by acessing REST API.
        /// First determine which DTO object to expect from api call and then map to domain object.
        /// Determining DTO object type and then calling generic method is little tricky. Don't be afraid of it.
        /// </summary>
        /// <typeparam name="T">Expected domain object.</typeparam>
        /// <param name="url">Full url path to resource.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task<T> GetByFullUrlAsync<T>(string url, CancellationToken ct) where T : class
        {
            return await ProcessApiCallAsync<T>(new Uri(url), HttpMethod.Get, null, null, ct);
        }

        /// <summary>
        /// Retrieves expected domain object by acessing REST API.
        /// First determine which DTO object to expect from api call and then map to domain object.
        /// Determining DTO object type and then calling generic method is little tricky. Don't be afraid of it.
        /// </summary>
        /// <typeparam name="T">Expected domain object.</typeparam>
        /// <param name="endpoint">Relative API url.</param>
        /// <param name="queryParameters">Url parameters.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task<T> GetAsync<T>(string endpoint, QueryParameters queryParameters, CancellationToken ct) where T : class
        {
            return await ProcessApiCallAsync<T>(ConstructEndpointPath(endpoint), HttpMethod.Get, queryParameters, null, ct);
        }

        /// <summary>
        /// Make API POST request.
        /// </summary>
        /// <param name="endpoint">Relative API url.</param>
        /// <param name="bodyParameters">Body content parameters.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task PostAsync(string endpoint, BodyParameters bodyParameters, CancellationToken ct)
        {
            await ProcessApiCallAsync(ConstructEndpointPath(endpoint), HttpMethod.Post, null, bodyParameters, ct);
        }

        /// <summary>
        /// Deletes object by REST API.
        /// </summary>
        /// <param name="endpoint">Relative API url.</param>
        /// <param name="queryParameters">Url parameters.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task DeleteAsync(string endpoint, QueryParameters queryParameters, CancellationToken ct)
        {
            await ProcessApiCallAsync(ConstructEndpointPath(endpoint), HttpMethod.Delete, queryParameters, null, ct);
        }

        /// <summary>
        /// Make API POST request and parse response to domain object.
        /// </summary>
        /// <typeparam name="T">Expected domain object to be returned.</typeparam>
        /// <param name="endpoint">Relative API url.</param>
        /// <param name="bodyParameters">Body content parameters.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task<T> PostAsync<T>(string endpoint, BodyParameters bodyParameters, CancellationToken ct) where T : class
        {
            return await ProcessApiCallAsync<T>(ConstructEndpointPath(endpoint), HttpMethod.Post, null, bodyParameters, ct);
        }

        /// <summary>
        /// Make POST request and save response to a file.
        /// </summary>
        /// <param name="targetFile">Path to result file.</param>
        /// <param name="endpoint">Relative API url.</param>
        /// <param name="bodyParameters">Body content parameters.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task DownloadToFilePostAsync(string targetFile, string endpoint, BodyParameters bodyParameters,
            CancellationToken ct)
        {
            var parametersAsDTOs = ConvertToDtoBodyParameters(bodyParameters);
            var apiResponse = await DownloadToFileAsync(targetFile, ConstructEndpointPath(endpoint), HttpMethod.Post, ct, bodyParameters: parametersAsDTOs);
            EnsureSuccessfullApiResponse(apiResponse);
        }

        private async Task<T> ProcessApiCallAsync<T>(Uri fullUrl, HttpMethod httpMethod, QueryParameters queryParameters,
            BodyParameters bodyParameters, CancellationToken ct) where T : class
        {
            var parametersAsDTOs = ConvertToDtoBodyParameters(bodyParameters);
            Type dtoType = _dtoResolver.GetDataTransferObjectRecursive(typeof(T));
            var sendMethod = CreateGenericSendAsyncMethodInfo(dtoType);
            var apiCallResponseType = typeof(ApiCallResponse<>).MakeGenericType(dtoType);
            var apiResponse = Convert.ChangeType(
                await sendMethod.InvokeAsync(this, new object[] { fullUrl, httpMethod, ct, queryParameters, parametersAsDTOs }),
                apiCallResponseType);
            EnsureSuccessfullApiResponse((ApiCallResponse)apiResponse);
            //map to object because of Automapper 10.0 .NET Framework
            //https://docs.automapper.org/en/latest/10.0-Upgrade-Guide.html#mapping-from-dynamic-in-net-4-6-1
            return _mapper.Map<T>(((dynamic)apiResponse).Content as object);
        }

        private async Task ProcessApiCallAsync(Uri fullUrl, HttpMethod httpMethod, QueryParameters queryParameters,
            BodyParameters bodyParameters, CancellationToken ct)
        {
            var parametersAsDTOs = ConvertToDtoBodyParameters(bodyParameters);
            var apiResponse = await SendAsync(fullUrl, httpMethod, ct, queryParameters: queryParameters, bodyParameters: parametersAsDTOs);
            EnsureSuccessfullApiResponse(apiResponse);
        }

        /// <summary>
        /// Class initialization.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="baseAddress"></param>
        /// <param name="dtoResolver"></param>
        /// <param name="mapper"></param>
        private void Setup(HttpClient client, Uri baseAddress, IDataTransferObjectResolver dtoResolver, IMapper mapper)
        {
            _httpClient = client;
            _baseAddress = baseAddress;
            _dtoResolver = dtoResolver;
            _mapper = mapper;

            BackupRepositories = new BackupRepositoryClient(this);
            Jobs = new JobClient(this);
            Mailboxes = new MailboxClient(this);
            OneDrives = new OneDriveClient(this);
            Organizations = new OrganizationClient(this);
            OrganizationUsers = new OrganizationUserClient(this);
            OrganizationSites = new OrganizationSiteClient(this);
            OrganizationGroups = new OrganizationGroupClient(this);
            SharePoints = new SharePointClient(this);
            RestoreSessions = new RestoreSessionClient(this);
            LicensedUsers = new LicensedUserClient(this);
        }

        /// <summary>
        /// Throws exception in case of non successful HTTP status code.
        /// </summary>
        /// <param name="apiResponse"></param>
        private void EnsureSuccessfullApiResponse(ApiCallResponse apiResponse)
        {
            var unsuccessfulResponse = false == apiResponse.StatusCode.IsSuccessStatusCode();
            if (unsuccessfulResponse)
            {
                throw new ApiCallException($"Api returned status code {(int)apiResponse.StatusCode}: {apiResponse.StringContent}");
            }
        }

        private Uri ConstructEndpointPath(string endpoint)
        {
            if (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Remove(0, 1);
            }

            return new Uri(_baseAddress, $"/v{ApiVersion}/{endpoint}");
        }

        /// <summary>
        /// Converts parameters, that are domain objects into their corresponding DTOs.
        /// </summary>
        /// <param name="parameters">Parameters with domain objects.</param>
        /// <returns></returns>
        private BodyParameters ConvertToDtoBodyParameters(BodyParameters parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            var convertedParameters = new BodyParameters();

            foreach (var bodyParameter in parameters.GetParameters())
            {
                var parameter = bodyParameter.Value;

                if (parameter == null)
                {
                    convertedParameters.AddNullParameter(bodyParameter.Key);
                    continue;
                }

                if (_dtoResolver.HasDataTransferObjectAssociated(parameter.GetType()))
                {
                    var dtoType = _dtoResolver.GetDataTransferObjectRecursive(parameter.GetType());
                    var methodInfo = _mapper.GetType().GetMethods()
                        .Single(x => x.Name == "Map"
                            && x.GetParameters().Length == 1
                            && x.GetGenericArguments().Length == 1);
                    var method = methodInfo.MakeGenericMethod(dtoType);
                    parameter = Convert.ChangeType(
                        method.Invoke(_mapper, new object[] { parameter }),
                        dtoType);
                }

                convertedParameters.AddOptionalParameter(bodyParameter.Key, parameter);
            }

            return convertedParameters;
        }

        private MethodInfo CreateGenericSendAsyncMethodInfo(Type dtoType)
        {
            return this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(x => x.Name == "SendAsync"
                             && x.IsGenericMethod)
                .MakeGenericMethod(dtoType);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}