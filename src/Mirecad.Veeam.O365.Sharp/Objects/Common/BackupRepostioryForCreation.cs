using Mirecad.Veeam.O365.Sharp.Objects.Enums;

namespace Mirecad.Veeam.O365.Sharp.Objects.Common
{
    public class BackupRepostioryForCreation
    {
        public string Name { get; set; }
        public string ProxyId { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public RetentionType RetentionType { get; set; }
        public RetentionPeriodType RetentionPeriodType { get; set; }
        public string DailyRetentionPeriod { get; set; }
        public string MonthlyRetentionPeriod { get; set; }
        public string YearlyRetentionPeriod { get; set; }
        public string RetentionFrequencyType { get; set; }
        public string DailyTime { get; set; }
        public DailyType DailyType { get; set; }
        public string MonthlyTime { get; set; }
        public string MonthlyDayNumber { get; set; }
        public string MonthlyDayOfWeek { get; set; }
        public bool AttachUsedRepository { get; set; }
        public string ObjectStorageId { get; set; }
        public string ObjectStorageCachePath { get; set; }
        public bool? ObjectStorageEncryptionEnabled { get; set; }
        public string EncryptionKeyId { get; set; }
    }
}