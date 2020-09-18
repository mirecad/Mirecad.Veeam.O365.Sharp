using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(SchedulePolicyDto))]
    public class SchedulePolicy
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