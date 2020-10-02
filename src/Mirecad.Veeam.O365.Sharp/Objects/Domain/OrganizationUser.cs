using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationUserDto))]
    public class OrganizationUser : OrganizationUserBase
    {
        private VeeamLink<Organization> _linksOrganization;
        private VeeamLink<VeeamPagedResult<OneDrive>> _linksOneDrives;

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OneDrive>> GetOneDrivesAsync(CancellationToken ct = default)
            => await _linksOneDrives.InvokeAsync(ct);
    }
}