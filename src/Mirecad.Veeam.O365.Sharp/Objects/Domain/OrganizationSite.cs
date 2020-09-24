using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Models;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationSiteDto))]
    public class OrganizationSite : OrganizationSiteDto
    {
        internal VeeamLink<VeeamPagedResult<OrganizationSite>> LinksChildren { get; set; }
        internal VeeamLink<Organization> LinksOrganization { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await LinksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetChildrenAsync(CancellationToken ct = default)
            => await LinksChildren.InvokeAsync(ct);
    }
}