using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(JobDto))]
    public class Job : JobDto
    {
        internal VeeamLink<Organization> LinksOrganization { get; set; }
        internal VeeamLink<BackupRepository> LinksBackupRepository { get; set; }
        internal VeeamLink<VeeamCollectionResult<JobSession>> LinksJobSessions { get; set; }
        internal VeeamLink<JobItemCollection> LinksExcludedItems { get; set; }
        internal VeeamLink<JobItemCollection> LinksSelectedItems { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await LinksOrganization.InvokeAsync(ct);

        public async Task<BackupRepository> GetBackupRepositoryAsync(CancellationToken ct = default)
            => await LinksBackupRepository.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<JobSession>> GetJobSessionsAsync(CancellationToken ct = default)
            => await LinksJobSessions.InvokeAsync(ct);

        public async Task<JobItemCollection> GetExcludedItemsAsync(CancellationToken ct = default)
            => await LinksExcludedItems.InvokeAsync(ct);

        public async Task<JobItemCollection> GetSelectedItemsAsync(CancellationToken ct = default)
            => await LinksSelectedItems.InvokeAsync(ct);
    }
}