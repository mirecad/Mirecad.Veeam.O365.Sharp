using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class RestoreSessionClient : IRestoreSessionClient
    {
        private readonly VeeamO365Client _baseClient;

        public RestoreSessionClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<OneDrive>> GetOneDrives(string restoreSessionId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));

            var url = $"restoresessions/{restoreSessionId}/organization/onedrive";
            return await _baseClient.GetAsync<VeeamPagedResult<OneDrive>>(url, null, ct);
        }
    }
}