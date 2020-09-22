using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationGroupDto))]
    public class OrganizationGroup : OrganizationGroupDto
    {
        internal VeeamLink<VeeamPagedResult<Organization>> LinksOrganization { get; set; }

        public async Task<VeeamPagedResult<Organization>> GetOrganizationAsync(CancellationToken ct = default)
            => await LinksOrganization.InvokeAsync(ct);
    }
}