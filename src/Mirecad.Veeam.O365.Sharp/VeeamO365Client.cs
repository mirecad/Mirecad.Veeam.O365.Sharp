using System;
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
    public class VeeamO365Client : RestClient, IDisposable
    {
        private const string ApiVersion = "4";

        private Uri _baseAddress;
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IDataTransferObjectResolver _dtoResolver;

        public IOrganizationClient Organization { get; private set; }

        protected VeeamO365Client(HttpClient client, Uri baseAddress, IDataTransferObjectResolver dtoResolver) : base(client)
        {
            var serviceContainer = DIContainer.Create(this, dtoResolver);
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

            Organization = new OrganizationClient(this);
        }

        private async Task<T> GetFullUrlAsync<T>(string url, CancellationToken ct) where T : class
        {
            return await base.SendAsync<T>(new Uri(url), HttpMethod.Get, ct);
        }

        private async Task<T> GetAsync<T>(string endpoint, QueryParameters queryParameters, CancellationToken ct) where T : class 
        {
            return await base.SendAsync<T>(ConstructEndpointPath(endpoint), HttpMethod.Get, ct, queryParameters);
        }

        private Uri ConstructEndpointPath(string endpoint)
        {
            if (endpoint.StartsWith("/"))
            {
                endpoint = endpoint.Remove(0, 1);
            }

            return new Uri(_baseAddress, $"/v{ApiVersion}/{endpoint}");
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