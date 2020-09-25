using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
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

        public async Task EnableJob(CancellationToken ct = default)
        {
            await _client.Jobs.StartJob(Id, ct);
        }

        public async Task DisableJob(CancellationToken ct = default)
        {
            await _client.Jobs.DisableJob(Id, ct);
        }

        public async Task StartJob(CancellationToken ct = default)
        {
            await _client.Jobs.StartJob(Id, ct);
        }

        public async Task StopJob(CancellationToken ct = default)
        {
            await _client.Jobs.StopJob(Id, ct);
        }

        public async Task StartJobRestoreSession(RestoreSessionExploreDetails sessionDetails, CancellationToken ct = default)
        {
            await _client.Jobs.StartJobRestoreSession(Id, sessionDetails, ct);
        }
    }
}