using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Models;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(UsedRepositoryDto))]
    public class UsedRepository : UsedRepositoryDto
    {
        internal VeeamLink<BackupRepository> LinksBackupRepository { get; set; }

        public async Task<BackupRepository> GetBackupRepositoryAsync(CancellationToken ct = default)
            => await LinksBackupRepository.InvokeAsync(ct);
    }
}