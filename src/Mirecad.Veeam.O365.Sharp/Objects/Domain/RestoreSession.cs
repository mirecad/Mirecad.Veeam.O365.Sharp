using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(RestoreSessionDto))]
    public class RestoreSession : RestoreSessionBase
    {
        private VeeamLink<Organization> _linksOrganization;
        private VeeamLink<VeeamPagedResult<RestoreSessionEvent>> _linksRestoreSessionEvents;

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<VeeamPagedResult<RestoreSessionEvent>> GetRestoreSessionEventsAsync(CancellationToken ct = default)
            => await _linksRestoreSessionEvents.InvokeAsync(ct);
    }
}