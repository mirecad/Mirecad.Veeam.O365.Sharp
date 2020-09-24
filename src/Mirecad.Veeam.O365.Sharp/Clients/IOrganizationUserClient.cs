using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOrganizationUserClient
    {
        Task<VeeamPagedResult<OrganizationUser>> GetUsersOfOrganization(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            string name = null,
            string userName = null,
            string displayName = null,
            CancellationToken ct = default
        );

        Task<OrganizationUser> GetUser(string organizationId, string userId, CancellationToken ct = default);
    }
}