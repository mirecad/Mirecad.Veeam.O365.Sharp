using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class SharePointClient : ISharePointClient
    {
        private readonly VeeamO365Client _baseClient;

        public SharePointClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<SharePointSite>> GetSharePointSitesAsync(string restoreSessionId,
            string parentSiteId = null,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));

            var parameters = new QueryParameters()
                .AddOptionalParameter("parentId", parentSiteId)
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset);

            var url = $"restoresessions/{restoreSessionId}/organization/sites";
            return await _baseClient.GetAsync<VeeamPagedResult<SharePointSite>>(url, parameters, ct);
        }
    }
}