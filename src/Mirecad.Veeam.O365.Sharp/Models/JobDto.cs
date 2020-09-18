using System;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
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
        public SchedulePolicyDto SchedulePolicy { get; set; }

        [JsonProperty("_links")]
        public JobLinksDto Links { get; set; }
    }

    public class JobLinksDto
    {
        public VeeamLinkDto Organization { get; set; }
        public VeeamLinkDto BackupRepository { get; set; }
        public VeeamLinkDto JobSessions { get; set; }
        public VeeamLinkDto ExcludedItems { get; set; }
        public VeeamLinkDto SelectedItems { get; set; }
    }
}