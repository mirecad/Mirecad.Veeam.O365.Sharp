using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IMailboxClient
    {
        Task<VeeamPagedResult<Mailbox>> GetMailboxesAsync(string restoreSessionId,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default);

        Task SaveMailboxToPstFileAsync(string targetFilePath, string restoreSessionId, string mailboxId, CancellationToken ct = default);
    }
}