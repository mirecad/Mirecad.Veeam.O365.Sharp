using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _client;

        public RestClient(HttpClient client)
        {
            _client = client;
        }

        protected virtual async Task<T> SendAsync<T>(Uri url, HttpMethod method, CancellationToken cancellationToken,
            QueryParameters queryParameters = null, BodyParameters bodyParameters = null) where T : class
        {
            //TODO: handle query params
            var urlString = ConstructUrlString(url, queryParameters);
            
            var requestMessage = new HttpRequestMessage(method, urlString);
            var response = await _client.SendAsync(requestMessage, cancellationToken);
            return await ProcessResponseAsync<T>(response);
        }

        private string ConstructUrlString(Uri url, QueryParameters queryParameters)
        {
            var parameters = queryParameters?.GetParameters()
                ?? new Dictionary<string, string>();
            var stringBuilder = new StringBuilder(url.ToString());
            if (parameters.Any() == false)
            {
                return stringBuilder.ToString();
            }

            stringBuilder.Append('?');
            foreach (var parameter in parameters)
            {
                stringBuilder.Append(HttpUtility.UrlEncode(parameter.Key));
                stringBuilder.Append('=');
                stringBuilder.Append(HttpUtility.UrlEncode(parameter.Value));
                stringBuilder.Append('&');
            }

            var urlString = stringBuilder.ToString();
            urlString = urlString.TrimEnd('&');
            return urlString;
        }

        private static async Task<T> ProcessResponseAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}