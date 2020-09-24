using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class BackupRepositoryClient : IBackupRepositoryClient
    {
        private readonly VeeamO365Client _baseClient;

        public BackupRepositoryClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<BackupRepository> GetBackupRepository(string repositoryId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(repositoryId, nameof(repositoryId));
            var url = $"backuprepositories/{repositoryId}";
            return await _baseClient.GetDomainObjectAsync<BackupRepository>(url, null, ct);
        }
    }
}