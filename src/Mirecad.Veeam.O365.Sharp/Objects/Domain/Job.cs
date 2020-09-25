using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(JobDto))]
    public class Job : JobDto
    {
        private readonly VeeamO365Client _client;

        private VeeamLink<Organization> _linksOrganization;
        private VeeamLink<BackupRepository> _linksBackupRepository;
        private VeeamLink<VeeamCollectionResult<JobSession>> _linksJobSessions;
        private VeeamLink<JobItemCollection> _linksExcludedItems;
        private VeeamLink<JobItemCollection> _linksSelectedItems;

        public Job(VeeamO365Client client)
        {
            _client = client;
        }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<BackupRepository> GetBackupRepositoryAsync(CancellationToken ct = default)
            => await _linksBackupRepository.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<JobSession>> GetJobSessionsAsync(CancellationToken ct = default)
            => await _linksJobSessions.InvokeAsync(ct);

        public async Task<JobItemCollection> GetExcludedItemsAsync(CancellationToken ct = default)
            => await _linksExcludedItems.InvokeAsync(ct);

        public async Task<JobItemCollection> GetSelectedItemsAsync(CancellationToken ct = default)
            => await _linksSelectedItems.InvokeAsync(ct);

        public async Task EnableJobAsync(CancellationToken ct = default)
        {
            await _client.Jobs.StartJobAsync(Id, ct);
        }

        public async Task DisableJobAsync(CancellationToken ct = default)
        {
            await _client.Jobs.DisableJobAsync(Id, ct);
        }

        public async Task StartJobAsync(CancellationToken ct = default)
        {
            await _client.Jobs.StartJobAsync(Id, ct);
        }

        public async Task StopJobAsync(CancellationToken ct = default)
        {
            await _client.Jobs.StopJobAsync(Id, ct);
        }

        public async Task<RestoreSession> StartJobRestoreSessionAsync(RestoreSessionExploreDetails sessionDetails, CancellationToken ct = default)
        {
            return await _client.Jobs.StartJobRestoreSessionAsync(Id, sessionDetails, ct);
        }
    }
}