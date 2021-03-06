﻿namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class BackupRepositoryBase
    {
        public bool? IsOutOfSync { get; set; }
        public long? CapacityBytes { get; set; }
        public long? FreeSpaceBytes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string RetentionType { get; set; }
        public string RetentionPeriodType { get; set; }
        public string YearlyRetentionPeriod { get; set; }
        public string RetentionFrequencyType { get; set; }
        public string DailyTime { get; set; }
        public string DailyType { get; set; }
        public string ProxyId { get; set; }
    }
}