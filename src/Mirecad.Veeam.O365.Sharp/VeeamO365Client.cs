using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Mirecad.Veeam.O365.Sharp.Clients;
using Mirecad.Veeam.O365.Sharp.Handlers;
using Mirecad.Veeam.O365.Sharp.Helpers;
using Mirecad.Veeam.O365.Sharp.Infrastructure;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;

namespace Mirecad.Veeam.O365.Sharp
{
    public class VeeamO365Client : RestClient, IDisposable, IVeeamO365Client
    {
        private const string ApiVersion = "4";

        private Uri _baseAddress;
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IDataTransferObjectResolver _dtoResolver;

        public IBackupRepositoryClient BackupRepositories { get; private set; }
        public IJobClient Jobs { get; private set; }
        public IOrganizationClient Organizations { get; private set; }
        public IOrganizationUserClient OrganizationUsers { get; private set; }
        public IOrganizationSiteClient OrganizationSites { get; private set; }
        public IOrganizationGroupClient OrganizationGroups { get; private set; }

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
                BaseAddress = options.BaseAddress
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
        internal async Task<T> GetDomainObjectByFullUrlAsync<T>(string url, CancellationToken ct) where T : class
        {
            Type dtoType = _dtoResolver.GetDataTransferObjectRecursive(typeof(T));
            var method = this.GetType().GetMethod("GetFullUrlAsync", BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(dtoType);
            var resultDto = Convert.ChangeType(
                await method.InvokeAsync(this, new object[] { url, ct }),
                dtoType);
            return _mapper.Map<T>(resultDto);
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
        internal async Task<T> GetDomainObjectAsync<T>(string endpoint, QueryParameters queryParameters, CancellationToken ct) where T : class
        {
            Type dtoType = _dtoResolver.GetDataTransferObjectRecursive(typeof(T));
            var method = this.GetType().GetMethod("GetAsync", BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(dtoType);
            var resultDto = Convert.ChangeType(
                await method.InvokeAsync(this, new object[] {endpoint, queryParameters, ct}),
                dtoType);
            return _mapper.Map<T>(resultDto);
        }

        /// <summary>
        /// Make API POST request and parse response to domain object.
        /// </summary>
        /// <typeparam name="T">Expected domain object to be returned.</typeparam>
        /// <param name="endpoint">Relative API url.</param>
        /// <param name="bodyParameters">Body content parameters.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        internal async Task<T> PostDomainObjectAsync<T>(string endpoint, BodyParameters bodyParameters, CancellationToken ct) where T : class
        {
            var parametersAsDtos = ConvertToDtoBodyParameters(bodyParameters);
            Type dtoType = _dtoResolver.GetDataTransferObjectRecursive(typeof(T));
            var method = this.GetType().GetMethod("PostAsync", BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(dtoType);
            var resultDto = Convert.ChangeType(
                await method.InvokeAsync(this, new object[] { endpoint, parametersAsDtos, ct }),
                dtoType);
            return _mapper.Map<T>(resultDto);
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
            Organizations = new OrganizationClient(this);
            OrganizationUsers = new OrganizationUserClient(this);
            OrganizationSites = new OrganizationSiteClient(this);
            OrganizationGroups = new OrganizationGroupClient(this);
        }

        private async Task<T> GetFullUrlAsync<T>(string url, CancellationToken ct) where T : class
        {
            return await base.SendAsync<T>(new Uri(url), HttpMethod.Get, ct);
        }

        private async Task<T> GetAsync<T>(string endpoint, QueryParameters queryParameters, CancellationToken ct) where T : class 
        {
            return await base.SendAsync<T>(ConstructEndpointPath(endpoint), HttpMethod.Get, ct, queryParameters);
        }

        private async Task<T> PostAsync<T>(string endpoint, BodyParameters bodyParameters, CancellationToken ct) where T : class
        {
            return await base.SendAsync<T>(ConstructEndpointPath(endpoint), HttpMethod.Post, bodyParameters: bodyParameters, cancellationToken: ct);
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
            var convertedParameters = new BodyParameters();

            foreach (var bodyParameter in parameters.GetParameters())
            {
                var parameter = bodyParameter.Value;
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