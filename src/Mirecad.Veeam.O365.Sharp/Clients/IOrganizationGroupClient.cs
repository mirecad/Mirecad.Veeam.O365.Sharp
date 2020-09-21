using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Models;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOrganizationGroupClient
    {
        Task<VeeamPagedResult<OrganizationGroup>> GetGroupsOfOrganization(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            string name = null,
            string groupName = null,
            string displayName = null,
            CancellationToken ct = default
        );

        Task<OrganizationGroup> GetGroup(string organizationId, string userId, CancellationToken ct = default);
    }
}