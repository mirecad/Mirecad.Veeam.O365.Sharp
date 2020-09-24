using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationSiteDto))]
    public class OrganizationSite : OrganizationSiteDto
    {
        private VeeamLink<VeeamPagedResult<OrganizationSite>> _linksChildren;
        private VeeamLink<Organization> _linksOrganization;

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetChildrenAsync(CancellationToken ct = default)
            => await _linksChildren.InvokeAsync(ct);
    }
}