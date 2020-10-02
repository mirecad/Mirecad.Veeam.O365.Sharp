using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(RestoreSessionEvent))]
    public class RestoreSessionEvent : RestoreSessionBase
    {
        private VeeamLink<RestoreSession> _linksRestoreSession;

        public async Task<RestoreSession> GetRestoreSessionAsync(CancellationToken ct = default)
            => await _linksRestoreSession.InvokeAsync(ct);
    }
}