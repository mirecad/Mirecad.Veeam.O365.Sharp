using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(UsedRepositoryDto))]
    public class UsedRepository : UsedRepositoryBase
    {
        private VeeamLink<BackupRepository> _linksBackupRepository;

        public async Task<BackupRepository> GetBackupRepositoryAsync(CancellationToken ct = default)
            => await _linksBackupRepository.InvokeAsync(ct);
    }
}