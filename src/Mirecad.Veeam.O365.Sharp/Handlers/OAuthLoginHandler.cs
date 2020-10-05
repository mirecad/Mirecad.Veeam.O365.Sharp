using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Handlers
{
    public class OAuthLoginHandler : HttpClientHandler
    {
        private readonly object _lock = new object();

        private readonly string _authEndpoint;
        private readonly NetworkCredential _credential;

        private string _bearerToken;
        private DateTimeOffset _tokenExpiresOnUtc = DateTimeOffset.MinValue;

        public OAuthLoginHandler(string authEndpoint, string username, SecureString password)
        {
            _authEndpoint = authEndpoint;
            _credential = new NetworkCredential(username, password);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenExpireInSeconds = (_tokenExpiresOnUtc - DateTimeOffset.Now).TotalSeconds;

            if (tokenExpireInSeconds > 60)
            {
                request.Headers.Add("Authorization", "Bearer " + _bearerToken);
                return await base.SendAsync(request, cancellationToken)
                    .ConfigureAwait(false);
            }

            lock (_lock)
            {
                //TODO: add support for refresh token
                ObtainBearerTokenAsync(cancellationToken);
            }
            request.Headers.Remove("Authorization");
            request.Headers.Add("Authorization", "Bearer " + _bearerToken);
            return await base.SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }

        private void ObtainBearerTokenAsync(CancellationToken cancelationToken)
        {
            var payload = new Dictionary<string, string>()
            {
                {"grant_type", "password"},
                {"username", _credential.UserName},
                {"password", _credential.Password}
            };
            using (var content = new FormUrlEncodedContent(payload))
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, _authEndpoint) {Content = content})
                {
                    using (var response = base.SendAsync(request, cancelationToken).ConfigureAwait(false).GetAwaiter()
                        .GetResult())
                    {
                        response.EnsureSuccessStatusCode();

                        string responseString = response.Content.ReadAsStringAsync().Result;
                        dynamic responseContent = JsonConvert.DeserializeObject(responseString);
                        _bearerToken = responseContent.access_token;
                        _tokenExpiresOnUtc = responseContent[".expires"];
                    }
                }
            }
        }
    }
}