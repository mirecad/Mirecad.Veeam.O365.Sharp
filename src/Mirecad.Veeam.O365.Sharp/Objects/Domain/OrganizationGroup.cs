using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationGroupDto))]
    public class OrganizationGroup : OrganizationGroupBase
    {
        private VeeamLink<VeeamPagedResult<Organization>> _linksOrganization;
        
        public async Task<VeeamPagedResult<Organization>> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);
    }
}