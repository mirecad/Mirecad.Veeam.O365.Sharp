using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IBackupRepositoryClient
    {
        Task<BackupRepository> GetBackupRepositoryAsync(string repositoryId, CancellationToken ct = default);

        Task<BackupRepository> AddBackupRepositoryAsync(BackupRepostioryForCreation newRepository,
            CancellationToken ct = default);

        Task RemoveBackupRepositoryAsync(string repositoryId, CancellationToken ct = default);
    }
}