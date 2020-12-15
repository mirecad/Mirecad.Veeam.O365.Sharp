using System.Threading;
using System.Threading.Tasks;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IRestoreSessionClient
    {
        Task StopRestoreSessionAsync(string restoreSessionId, CancellationToken ct = default);
    }
}