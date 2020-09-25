using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOrganizationSiteClient
    {
        Task<VeeamPagedResult<OrganizationSite>> GetSitesOfOrganizationAsync(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            CancellationToken ct = default
        );

        Task<OrganizationSite> GetSiteAsync(string organizationId, string siteId, CancellationToken ct = default);
    }
}