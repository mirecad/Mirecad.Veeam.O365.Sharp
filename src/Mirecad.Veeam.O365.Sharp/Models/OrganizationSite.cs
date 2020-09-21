using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(OrganizationSiteDto))]
    public class OrganizationSite
    {
        private VeeamLink<VeeamPagedResult<OrganizationSite>> _linksChildren;
        private VeeamLink<Organization> _linksOrganization;

        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool IsCloud { get; set; }
        public bool IsPersonal { get; set; }
        public string Title { get; set; }
        public bool IsBackedUp { get; set; }
        public bool IsAvailable { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetChildrenAsync(CancellationToken ct = default)
            => await _linksChildren.InvokeAsync(ct);
    }
}