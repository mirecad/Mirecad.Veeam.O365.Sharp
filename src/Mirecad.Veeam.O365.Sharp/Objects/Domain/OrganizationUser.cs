using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Models;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationUserDto))]
    public class OrganizationUser : OrganizationUserDto
    {
        internal VeeamLink<Organization> LinksOrganization { get; set; }
        internal VeeamLink<VeeamPagedResult<OneDrive>> LinksOneDrives { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await LinksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OneDrive>> GetOneDrivesAsync(CancellationToken ct = default)
            => await LinksOneDrives.InvokeAsync(ct);
    }
}