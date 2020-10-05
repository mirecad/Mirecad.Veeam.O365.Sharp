 using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOneDriveClient
    {
        Task<VeeamPagedResult<OneDrive>> GetOneDrivesAsync(string restoreSessionId,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default);

        Task<VeeamPagedResult<OneDriveDocument>> GetOneDriveDocumentsAsync(string restoreSessionId, 
            string oneDriveId,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default);

        Task SaveOneDriveItemToFileAsync(string targetFilePath, string restoreSessionId, string oneDriveId, CancellationToken ct = default);

        Task SaveOneDriveDocumentsToFileAsync(string targetFilePath, 
            string restoreSessionId, 
            string oneDriveId, 
            IEnumerable<OneDriveDocument> documents, 
            bool? asZip = null,
            CancellationToken ct = default);

        Task SaveOneDriveDocumentToFileAsync(string targetFilePath,
            string restoreSessionId,
            string oneDriveId,
            string oneDriveDocumentId,
            bool? asZip = null,
            CancellationToken ct = default);
    }
}