using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(OrganizationGroupDto))]
    public class OrganizationGroup
    {
        private VeeamLink<VeeamPagedResult<Organization>> _linksOrganization;

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string ManagedBy { get; set; }
        public string Site { get; set; }
        public string Type { get; set; }
        public string LocationType { get; set; }
        public bool IsBackedUp { get; set; }

        public async Task<VeeamPagedResult<Organization>> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);
    }
}