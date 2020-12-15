using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Mirecad.Veeam.O365.Sharp.Converters;
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

        /// <summary>
        /// Executes given HTTP method and parses response to expected return type.
        /// </summary>
        /// <typeparam name="T">Expected return type from API.</typeparam>
        /// <param name="url">Full resource URL.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="queryParameters">URL parameters.</param>
        /// <param name="bodyParameters">Parameters, that will be sent in body of the request.</param>
        /// <returns></returns>
        protected virtual async Task<ApiCallResponse<T>> SendAsync<T>(Uri url, HttpMethod method, CancellationToken cancellationToken,
            QueryParameters queryParameters = null, BodyParameters bodyParameters = null) where T : class
        {
            using (var requestMessage = ConstructRequestMessage(method, url, queryParameters, bodyParameters))
            {
                using (var response = await _client.SendAsync(requestMessage, cancellationToken))
                {
                    return await ProcessResponseAsync<T>(response);
                }
            }
        }

        /// <summary>
        /// Executes given HTTP method. Does not expect any response content.
        /// </summary>
        /// <param name="url">Full resource URL.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="queryParameters">URL parameters.</param>
        /// <param name="bodyParameters">Parameters, that will be sent in body of the request.</param>
        /// <returns></returns>
        protected virtual async Task<ApiCallResponse> SendAsync(Uri url, HttpMethod method, CancellationToken cancellationToken,
            QueryParameters queryParameters = null, BodyParameters bodyParameters = null)
        {
            using (var requestMessage = ConstructRequestMessage(method, url, queryParameters, bodyParameters))
            {
                using (var response = await _client.SendAsync(requestMessage, cancellationToken))
                {
                    return await ProcessResponseAsync(response);
                }
            }
        }

        /// <summary>
        /// Executes given HTTP method and saves returned data to file. Method is capable of downloading large files.
        /// Data is not stored in memory, but is written directly to file on disk.
        /// </summary>
        /// <param name="targetFile">Returned data will be written to this file.</param>
        /// <param name="url">Full resource URL.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="queryParameters">URL parameters.</param>
        /// <param name="bodyParameters">Parameters, that will be sent in body of the request.</param>
        /// <returns></returns>
        protected virtual async Task<ApiCallResponse> DownloadToFileAsync(string targetFile, Uri url, HttpMethod method,
            CancellationToken cancellationToken, QueryParameters queryParameters = null, BodyParameters bodyParameters = null)
        {
            using (var requestMessage = ConstructRequestMessage(method, url, queryParameters, bodyParameters))
            {
                using (var response = await _client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken))
                {
                    var apiCallResponse = await ProcessResponseAsync(response, false);
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        using (Stream streamToWriteTo = File.Open(targetFile, FileMode.Create))
                        {
                            await streamToReadFrom.CopyToAsync(streamToWriteTo);
                            return apiCallResponse;
                        }
                    }
                }
            }
        }

        private HttpRequestMessage ConstructRequestMessage(HttpMethod method, Uri url, QueryParameters queryParameters, BodyParameters bodyParameters)
        {
            var urlString = ConstructUrlString(url, queryParameters);
            var request = new HttpRequestMessage(method, urlString);
            var hasBody = bodyParameters != null && bodyParameters.GetParameters().Any();
            if (hasBody)
            {
                var jsonString = ConvertToJson(bodyParameters);
                request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }
            return request;
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

        private async Task<ApiCallResponse<T>> ProcessResponseAsync<T>(HttpResponseMessage response)
        {
            var stringContent = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(stringContent);
            return new ApiCallResponse<T>
            {
                Content = content,
                StatusCode = response.StatusCode,
                StringContent = stringContent
            };
        }

        private async Task<ApiCallResponse> ProcessResponseAsync(HttpResponseMessage response, bool loadContent = true)
        {
            var apiCallResponse =  new ApiCallResponse()
            {
                StatusCode = response.StatusCode,
            };
            if (loadContent)
            {
                apiCallResponse.StringContent = await response.Content.ReadAsStringAsync();
            }

            return apiCallResponse;
        }

        private string ConvertToJson(BodyParameters parameters)
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
            jsonSettings.Converters.Add(new BodyParametersConverter());
            return jsonSettings;
        }
    }
}