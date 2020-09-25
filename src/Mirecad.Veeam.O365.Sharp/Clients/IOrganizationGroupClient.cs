using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOrganizationGroupClient
    {
        Task<VeeamPagedResult<OrganizationGroup>> GetGroupsOfOrganizationAsync(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            string name = null,
            string groupName = null,
            string displayName = null,
            CancellationToken ct = default
        );

        Task<OrganizationGroup> GetGroupAsync(string organizationId, string userId, CancellationToken ct = default);
    }
}