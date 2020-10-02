using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class OneDriveClient : IOneDriveClient
    {
        private readonly VeeamO365Client _baseClient;

        public OneDriveClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<OneDrive>> GetOneDrivesAsync(string restoreSessionId,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));

            var parameters = new QueryParameters()
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset);

            var url = $"restoresessions/{restoreSessionId}/organization/onedrives";
            return await _baseClient.GetAsync<VeeamPagedResult<OneDrive>>(url, parameters, ct);
        }

        public async Task<VeeamPagedResult<OneDriveDocument>> GetOneDriveDocumentsAsync(string restoreSessionId, 
            string oneDriveId,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));
            ParameterValidator.ValidateNotNull(oneDriveId, nameof(oneDriveId));

            var parameters = new QueryParameters()
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset);

            var url = $"restoresessions/{restoreSessionId}/organization/onedrives/{oneDriveId}/documents";
            return await _baseClient.GetAsync<VeeamPagedResult<OneDriveDocument>>(url, parameters, ct);
        }

        public async Task SaveOneDriveItemToFileAsync(string targetFilePath, string restoreSessionId, string oneDriveId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(targetFilePath, nameof(targetFilePath));
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));
            ParameterValidator.ValidateNotNull(oneDriveId, nameof(oneDriveId));

            var bodyParameters = new BodyParameters()
                .AddNullParameter("save");

            var url = $"restoresessions/{restoreSessionId}/organization/onedrives/{oneDriveId}/action";
            await _baseClient.DownloadToFilePostAsync(targetFilePath, url, bodyParameters, ct);
        }

        public async Task SaveOneDriveDocumentsToFileAsync(string targetFilePath, 
            string restoreSessionId, 
            string oneDriveId, 
            IEnumerable<OneDriveDocument> documents, 
            bool? asZip = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(targetFilePath, nameof(targetFilePath));
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));
            ParameterValidator.ValidateNotNull(oneDriveId, nameof(oneDriveId));
            ParameterValidator.ValidateNotNull(documents, nameof(documents));

            var action = new SaveDocumentsAction
            {
                AsZip = asZip.ToString(),
                Documents = documents.ToList()
            };

            var bodyParameters = new BodyParameters()
                .AddMandatoryParameter("save", action);

            var url = $"restoresessions/{restoreSessionId}/organization/onedrives/{oneDriveId}/documents/action";
            await _baseClient.DownloadToFilePostAsync(targetFilePath, url, bodyParameters, ct);
        }

        public async Task SaveOneDriveDocumentToFileAsync(string targetFilePath,
            string restoreSessionId,
            string oneDriveId,
            string oneDriveDocumentId,
            bool? asZip = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(targetFilePath, nameof(targetFilePath));
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));
            ParameterValidator.ValidateNotNull(oneDriveId, nameof(oneDriveId));
            ParameterValidator.ValidateNotNull(oneDriveDocumentId, nameof(oneDriveDocumentId));
            
            var bodyParameters = new BodyParameters();
            if (asZip != null)
            {
                bodyParameters.AddMandatoryParameter("save", new {asZip = asZip.ToString()});
            }
            else
            {
                bodyParameters.AddNullParameter("save");
            }

            var url = $"restoresessions/{restoreSessionId}/organization/onedrives/{oneDriveId}/documents/{oneDriveDocumentId}/action";
            await _baseClient.DownloadToFilePostAsync(targetFilePath, url, bodyParameters, ct);
        }
    }
}