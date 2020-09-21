using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Models;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class OrganizationSiteClient : IOrganizationSiteClient
    {
        private readonly VeeamO365Client _baseClient;

        public OrganizationSiteClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<OrganizationSite>> GetSitesOfOrganization(string organizationId, int? limit = null, int? offset = null, string setId = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));

            var parameters = new QueryParameters()
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset)
                .AddOptionalParameter("setId", setId);

            var url = $"organizations/{organizationId}/sites";
            return await _baseClient.GetDomainObjectAsync<VeeamPagedResult<OrganizationSite>>(url, parameters, ct);
        }

        public async Task<OrganizationSite> GetSite(string organizationId, string siteId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));
            ParameterValidator.ValidateNotNull(siteId, nameof(siteId));

            var url = $"organizations/{organizationId}/users/{siteId}";
            return await _baseClient.GetDomainObjectAsync<OrganizationSite>(url, null, ct);
        }
    }
}