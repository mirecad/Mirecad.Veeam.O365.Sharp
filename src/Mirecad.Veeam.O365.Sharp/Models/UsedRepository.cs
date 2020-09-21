using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(UsedRepositoryDto))]
    public class UsedRepository
    {
        private VeeamLink<BackupRepository> _linksBackupRepository;

        public long UsedSpaceBytes { get; set; }
        public int LocalCacheUsedSpaceBytes { get; set; }
        public int ObjectStorageUsedSpaceBytes { get; set; }
        public bool IsAvailable { get; set; }
        public string Details { get; set; }

        public async Task<BackupRepository> GetBackupRepositoryAsync(CancellationToken ct = default)
            => await _linksBackupRepository.InvokeAsync(ct);
    }
}