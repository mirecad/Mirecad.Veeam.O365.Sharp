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

        public async Task<VeeamCollectionResult<Job>> GetJobs(CancellationToken ct = default)
        {
            var url = "jobs";
            return await _baseClient.GetAsync<VeeamCollectionResult<Job>>(url, null, ct);
        }

        public async Task<Job> CreateJobForOrganization(string organizationId,
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

        public async Task StartJob(string jobId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(jobId, nameof(jobId));

            var bodyParameters = new BodyParameters()
                .AddNullParameter("start");

            var url = $"jobs/{jobId}/action";
            await _baseClient.PostAsync(url, bodyParameters, ct);
        }

        public async Task<Job> GetJob(string jobId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(jobId, nameof(jobId));

            var url = $"jobs/{jobId}";
            return await _baseClient.GetAsync<Job>(url, null, ct);
        }

        public async Task<VeeamCollectionResult<Job>> GetJobsOfOrganization(string organizationId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));

            var url = $"organizations/{organizationId}/jobs";
            return await _baseClient.GetAsync<VeeamCollectionResult<Job>>(url, null, ct);
        }
    }
}