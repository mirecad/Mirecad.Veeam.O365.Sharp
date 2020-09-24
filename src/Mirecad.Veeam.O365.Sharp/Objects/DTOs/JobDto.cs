using System;
using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastRun { get; set; }
        public DateTime? NextRun { get; set; }
        public bool IsEnabled { get; set; }
        public string BackupType { get; set; }
        public string LastStatus { get; set; }
        public SchedulePolicy SchedulePolicy { get; set; }

        [JsonProperty("_links")]
        internal JobLinksDto Links { get; set; }
    }

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

    internal class JobLinksDto
    {
        public VeeamLinkDto Organization { get; set; }
        public VeeamLinkDto BackupRepository { get; set; }
        public VeeamLinkDto JobSessions { get; set; }
        public VeeamLinkDto ExcludedItems { get; set; }
        public VeeamLinkDto SelectedItems { get; set; }
    }
}