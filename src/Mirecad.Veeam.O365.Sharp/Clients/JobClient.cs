using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class JobClient : IJobClient
    {
        private readonly VeeamO365Client _baseClient;

        public JobClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamCollectionResult<Job>> GetJobsAsync(CancellationToken ct = default)
        {
            var url = "jobs";
            return await _baseClient.GetAsync<VeeamCollectionResult<Job>>(url, null, ct);
        }

        public async Task<Job> CreateJobForOrganizationAsync(string organizationId,
            string repositoryId,
            string name,
            string description,
            BackupType backupType,
            SchedulePolicy schedulePolicy,
            JobItemCollection selectedItems,
            string proxyId,
            bool runNow,
            CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));

            var bodyParameters = new BodyParameters()
                .AddOptionalParameter("Name", name)
                .AddOptionalParameter("Description", description)
                .AddOptionalParameter("BackupType", backupType)
                .AddOptionalParameter("SchedulePolicy", schedulePolicy)
                .AddOptionalParameter("SelectedItems", selectedItems)
                .AddOptionalParameter("ProxyId", proxyId)
                .AddMandatoryParameter("RepositoryId", repositoryId)
                .AddOptionalParameter("RunNow", runNow);

            var url = $"organizations/{organizationId}/jobs";
            return await _baseClient.PostAsync<Job>(url, bodyParameters, ct);
        }

        public async Task EnableJobAsync(string jobId, CancellationToken ct = default)
        {
            await PostAction("enable", jobId, ct);
        }

        public async Task DisableJobAsync(string jobId, CancellationToken ct = default)
        {
            await PostAction("disable", jobId, ct);
        }

        public async Task StartJobAsync(string jobId, CancellationToken ct = default)
        {
            await PostAction("start", jobId, ct);
        }

        public async Task StopJobAsync(string jobId, CancellationToken ct = default)
        {
            await PostAction("stop", jobId, ct);
        }

        public async Task<RestoreSession> StartJobRestoreSessionAsync(string jobId, RestoreSessionExploreDetails sessionDetails, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(jobId, nameof(jobId));

            var bodyParameters = new BodyParameters()
                .AddMandatoryParameter("explore", sessionDetails);

            var url = $"jobs/{jobId}/action";
            return await _baseClient.PostAsync<RestoreSession>(url, bodyParameters, ct);
        }

        public async Task<Job> GetJobAsync(string jobId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(jobId, nameof(jobId));

            var url = $"jobs/{jobId}";
            return await _baseClient.GetAsync<Job>(url, null, ct);
        }

        public async Task<VeeamCollectionResult<Job>> GetJobsOfOrganizationAsync(string organizationId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));

            var url = $"organizations/{organizationId}/jobs";
            return await _baseClient.GetAsync<VeeamCollectionResult<Job>>(url, null, ct);
        }

        private async Task PostAction(string action, string jobId, CancellationToken ct)
        {
            ParameterValidator.ValidateNotNull(jobId, nameof(jobId));

            var bodyParameters = new BodyParameters()
                .AddNullParameter(action);

            var url = $"jobs/{jobId}/action";
            await _baseClient.PostAsync(url, bodyParameters, ct);
        }
    }
}