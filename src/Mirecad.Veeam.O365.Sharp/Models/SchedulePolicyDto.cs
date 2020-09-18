namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class SchedulePolicyDto
    {
        public bool ScheduleEnabled { get; set; }
        public bool BackupWindowEnabled { get; set; }
        public string Type { get; set; }
        public string PeriodicallyEver { get; set; }
        public bool RetryEnabled { get; set; }
        public int RetryNumber { get; set; }
        public int RetryWaitInterval { get; set; }
    }
}