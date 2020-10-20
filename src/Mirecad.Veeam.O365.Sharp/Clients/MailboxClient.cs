using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class MailboxClient : IMailboxClient
    {
        private readonly VeeamO365Client _baseClient;

        public MailboxClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<Mailbox>> GetMailboxesAsync(string restoreSessionId,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));

            var parameters = new QueryParameters()
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset);

            var url = $"restoresessions/{restoreSessionId}/organization/mailboxes";
            return await _baseClient.GetAsync<VeeamPagedResult<Mailbox>>(url, parameters, ct);
        }

        public async Task SaveMailboxToPstFileAsync(string targetFilePath, string restoreSessionId, string mailboxId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(targetFilePath, nameof(targetFilePath));
            ParameterValidator.ValidateNotNull(restoreSessionId, nameof(restoreSessionId));
            ParameterValidator.ValidateNotNull(mailboxId, nameof(mailboxId));

            var action = new
            {
                EnablePstSizeLimit = false
            };

            var bodyParameters = new BodyParameters()
                .AddMandatoryParameter("exportToPst", action);

            var url = $"restoresessions/{restoreSessionId}/organization/mailboxes/{mailboxId}/action";
            await _baseClient.DownloadToFilePostAsync(targetFilePath, url, bodyParameters, ct);
        }
    }
}