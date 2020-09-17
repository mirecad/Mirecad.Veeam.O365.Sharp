using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(OneDriveDto))]
    public class OneDrive
    {
        private VeeamLink<OrganizationUser> _linksUser;

        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public async Task<OrganizationUser> GetUserAsync(CancellationToken ct = default)
            => await _linksUser.InvokeAsync(ct);
    }
}