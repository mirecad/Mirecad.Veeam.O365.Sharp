using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(JobDto))]
    public class Job
    {
        private VeeamLink<Organization> _linksOrganization;
        private VeeamLink<BackupRepository> _linksBackupRepository;
        private VeeamLink<VeeamCollectionResult<JobSession>> _linksJobSessions;
        private VeeamLink<JobItemCollectionResult> _linksExcludedItems;
        private VeeamLink<JobItemCollectionResult> _linksSelectedItems;

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsBackedUp { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);

        public async Task<BackupRepository> GetBackupRepositoryAsync(CancellationToken ct = default)
            => await _linksBackupRepository.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<JobSession>> GetJobSessionsAsync(CancellationToken ct = default)
            => await _linksJobSessions.InvokeAsync(ct);

        public async Task<JobItemCollectionResult> GetExcludedItemsAsync(CancellationToken ct = default)
            => await _linksExcludedItems.InvokeAsync(ct);

        public async Task<JobItemCollectionResult> GetSelectedItemsAsync(CancellationToken ct = default)
            => await _linksSelectedItems.InvokeAsync(ct);
    }
}