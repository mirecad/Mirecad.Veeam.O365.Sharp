using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IJobClient
    {
        Task<VeeamCollectionResult<Job>> GetJobsAsync(CancellationToken ct = default);
        Task<Job> GetJobAsync(string jobId, CancellationToken ct = default);
        Task<VeeamCollectionResult<Job>> GetJobsOfOrganizationAsync(string organizationId, CancellationToken ct = default);
        Task<Job> CreateJobForOrganizationAsync(string organizationId,
            string repositoryId,
            string name,
            string description,
            BackupType backupType,
            SchedulePolicy schedulePolicy,
            JobItemCollection selectedItems,
            string proxyId,
            bool runNow,
            CancellationToken ct = default);

        Task EnableJobAsync(string jobId, CancellationToken ct = default);
        Task DisableJobAsync(string jobId, CancellationToken ct = default);
        Task StartJobAsync(string jobId, CancellationToken ct = default);
        Task StopJobAsync(string jobId, CancellationToken ct = default);
        Task StartJobRestoreSessionAsync(string jobId, RestoreSessionExploreDetails sessionDetails, CancellationToken ct = default);
    }
}