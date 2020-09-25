using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IJobClient
    {
        Task<VeeamCollectionResult<Job>> GetJobs(CancellationToken ct = default);
        Task<Job> GetJob(string jobId, CancellationToken ct = default);
        Task<VeeamCollectionResult<Job>> GetJobsOfOrganization(string organizationId, CancellationToken ct = default);
        Task<Job> CreateJobForOrganization(string organizationId,
            string repositoryId,
            string name,
            string description,
            BackupType backupType,
            SchedulePolicy schedulePolicy,
            JobItemCollection selectedItems,
            string proxyId,
            bool runNow,
            CancellationToken ct = default);

        Task EnableJob(string jobId, CancellationToken ct = default);
        Task DisableJob(string jobId, CancellationToken ct = default);
        Task StartJob(string jobId, CancellationToken ct = default);
        Task StopJob(string jobId, CancellationToken ct = default);
        Task StartJobRestoreSession(string jobId, RestoreSessionExploreDetails sessionDetails, CancellationToken ct = default);
    }
}