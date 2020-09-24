using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IBackupRepositoryClient
    {
        Task<BackupRepository> GetBackupRepository(string repositoryId, CancellationToken ct = default);
    }
}