namespace Mirecad.Veeam.O365.Sharp.Objects.Common
{
    public class SchedulePolicy
    {
        public bool? ScheduleEnabled { get; set; }
        public string Type { get; set; }
        public string DailyType { get; set; }
        public string DailyTime { get; set; }
        public string PeriodicInterval { get; set; }
        public bool? BackupWindowEnabled { get; set; }
        public BackupWindowSettings BackupWindowSettings { get; set; }
        public bool? RetryEnabled { get; set; }
        public int? RetryNumber { get; set; }
        public int? RetryWaitInterval { get; set; }
    }
}