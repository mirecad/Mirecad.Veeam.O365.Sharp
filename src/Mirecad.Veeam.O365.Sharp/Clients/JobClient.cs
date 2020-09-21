using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Models;

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
            return await _baseClient.GetDomainObjectAsync<VeeamCollectionResult<Job>>(url, null, ct);
        }

        public async Task<Job> GetJob(string jobId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(jobId, nameof(jobId));

            var url = $"jobs/{jobId}";
            return await _baseClient.GetDomainObjectAsync<Job>(url, null, ct);
        }

        public async Task<VeeamCollectionResult<Job>> GetJobsOfOrganization(string organizationId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));

            var url = $"organizations/{organizationId}/jobs";
            return await _baseClient.GetDomainObjectAsync<VeeamCollectionResult<Job>>(url, null, ct);
        }
    }
}