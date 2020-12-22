using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
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

        public async Task<BackupRepository> GetBackupRepositoryAsync(string repositoryId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(repositoryId, nameof(repositoryId));
            var url = $"backuprepositories/{repositoryId}";
            return await _baseClient.GetAsync<BackupRepository>(url, null, ct);
        }

        public async Task<BackupRepository> AddBackupRepositoryAsync(BackupRepostioryForCreation newRepository,
            CancellationToken ct = default)
        {
            var bodyParameters = new BodyParameters()
                .AddOptionalParameter("Name", newRepository.Name)
                .AddOptionalParameter("ProxyId", newRepository.ProxyId)
                .AddOptionalParameter("Path", newRepository.Path)
                .AddOptionalParameter("Description", newRepository.Description)
                .AddOptionalParameter("RetentionType", newRepository.RetentionType)
                .AddOptionalParameter("RetentionPeriodType", newRepository.RetentionPeriodType)
                .AddOptionalParameter("DailyRetentionPeriod", newRepository.DailyRetentionPeriod)
                .AddOptionalParameter("MonthlyRetentionPeriod", newRepository.MonthlyRetentionPeriod)
                .AddOptionalParameter("YearlyRetentionPeriod", newRepository.YearlyRetentionPeriod)
                .AddOptionalParameter("RetentionFrequencyType", newRepository.RetentionFrequencyType)
                .AddOptionalParameter("DailyTime", newRepository.DailyTime)
                .AddOptionalParameter("DailyType", newRepository.DailyType)
                .AddOptionalParameter("MonthlyTime", newRepository.MonthlyTime)
                .AddOptionalParameter("MonthlyDayNumber", newRepository.MonthlyDayNumber)
                .AddOptionalParameter("MonthlyDayOfWeek", newRepository.MonthlyDayOfWeek)
                .AddOptionalParameter("AttachUsedRepository", newRepository.AttachUsedRepository)
                .AddOptionalParameter("ObjectStorageId", newRepository.ObjectStorageId)
                .AddOptionalParameter("ObjectStorageCachePath", newRepository.ObjectStorageCachePath)
                .AddOptionalParameter("ObjectStorageEncryptionEnabled", newRepository.ObjectStorageEncryptionEnabled)
                .AddOptionalParameter("EncryptionKeyId", newRepository.EncryptionKeyId);

            var url = "backuprepositories";
            return await _baseClient.PostAsync<BackupRepository>(url, bodyParameters, ct);
        }

        public async Task RemoveBackupRepositoryAsync(string repositoryId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(repositoryId, nameof(repositoryId));
            var url = $"backuprepositories/{repositoryId}";
            await _baseClient.DeleteAsync(url, null, ct);
        }
    }
}