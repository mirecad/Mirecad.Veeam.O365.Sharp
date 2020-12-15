using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class RestoreSessionClient : IRestoreSessionClient
    {
        private readonly VeeamO365Client _baseClient;

        public RestoreSessionClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task StopRestoreSessionAsync(string restoreSessionId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));

            var bodyParameters = new BodyParameters()
                .AddNullParameter("stop");

            var url = $"restoresessions/{restoreSessionId}/action";
            await _baseClient.PostAsync(url, bodyParameters, ct);
        }
    }
}