using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Models;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOrganizationClient
    {
        Task<VeeamListResult<Organization>> GetOrganizations(CancellationToken ct = default);

        Task<VeeamPagedResult<User>> GetUsersOfOrganization(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            string name = null,
            string userName = null,
            string displayName = null,
            CancellationToken ct = default
        );
    }
}