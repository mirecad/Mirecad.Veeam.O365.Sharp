using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface ILicensedUserClient
    {
        Task RevokeLicenseFromUserAsync(string licensedUserId, CancellationToken ct = default);

        Task<VeeamPagedResult<LicensedUser>> GetLicensedUsersAsync(string organizationId = null,
            string name = null,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default);
    }
}