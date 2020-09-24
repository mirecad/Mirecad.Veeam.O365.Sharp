using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
            var urlString = ConstructUrlString(url, queryParameters);
            using var requestMessage = ConstructRequestMessage(method, urlString, bodyParameters);

            using var response = await _client.SendAsync(requestMessage, cancellationToken);
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

        private HttpRequestMessage ConstructRequestMessage(HttpMethod method, string url, BodyParameters bodyParameters)
        {
            var parameters = bodyParameters?.GetParameters()
                             ?? new Dictionary<string, object>();

            var jsonString = ConvertToJson(parameters);
            var request = new HttpRequestMessage(method, url);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return request;
        }

        private static async Task<T> ProcessResponseAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        private string ConvertToJson(Dictionary<string, object> parameters)
        {
            var jsonSettings = CreateJsonSerializerSettings();
            var jsonString = JsonConvert.SerializeObject(parameters, jsonSettings);
            return jsonString;
        }

        private JsonSerializerSettings CreateJsonSerializerSettings()
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonSettings.Converters.Add(new StringEnumConverter());
            return jsonSettings;
        }
    }
}