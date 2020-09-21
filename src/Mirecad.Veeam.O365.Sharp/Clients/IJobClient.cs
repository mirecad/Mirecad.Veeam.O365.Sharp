using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Models;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IJobClient
    {
        Task<VeeamCollectionResult<Job>> GetJobs(CancellationToken ct = default);
        Task<Job> GetJob(string jobId, CancellationToken ct = default);
        Task<VeeamCollectionResult<Job>> GetJobsOfOrganization(string organizationId, CancellationToken ct = default);
    }
}