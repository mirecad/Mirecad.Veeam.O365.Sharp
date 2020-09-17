using System.Threading;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using System.Threading.Tasks;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(OrganizationUserDto))]
    public class OrganizationUser
    {
        private VeeamLink<Organization> _linksOrganization;
        private VeeamLink<VeeamPagedResult<OneDrive>> _linksOneDrives;

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsBackedUp { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OneDrive>> GetOneDrivesAsync(CancellationToken ct = default)
            => await _linksOneDrives.InvokeAsync(ct);
    }
}