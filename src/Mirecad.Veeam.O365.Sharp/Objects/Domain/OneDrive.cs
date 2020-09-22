using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OneDriveDto))]
    public class OneDrive : OneDriveDto
    {
        internal VeeamLink<OrganizationUser> LinksUser { get; set; }

        public async Task<OrganizationUser> GetUserAsync(CancellationToken ct = default)
            => await LinksUser.InvokeAsync(ct);
    }
}