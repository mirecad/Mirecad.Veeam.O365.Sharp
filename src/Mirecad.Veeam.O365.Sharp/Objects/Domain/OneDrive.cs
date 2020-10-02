using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OneDriveDto))]
    public class OneDrive : OneDriveBase
    {
        private VeeamLink<OrganizationUser> _linksUser;

        public async Task<OrganizationUser> GetUserAsync(CancellationToken ct = default)
            => await _linksUser.InvokeAsync(ct);
    }
}