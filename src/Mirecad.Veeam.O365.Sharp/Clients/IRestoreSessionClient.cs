using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IRestoreSessionClient
    {
        Task<VeeamPagedResult<OneDrive>> GetOneDrives(string restoreSessionId, CancellationToken ct = default);
    }
}