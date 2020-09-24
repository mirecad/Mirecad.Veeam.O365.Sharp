using System;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastRun { get; set; }
        public DateTime? NextRun { get; set; }
        public bool? IsEnabled { get; set; }
        public string LastStatus { get; set; }
        public SchedulePolicy SchedulePolicy { get; set; }
        public BackupType BackupType { get; set; }

        [JsonIgnore]
        [JsonProperty("_links")]
        internal JobLinksDto Links { get; set; }
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