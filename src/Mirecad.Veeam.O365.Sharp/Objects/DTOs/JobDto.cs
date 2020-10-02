using System;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobDto : JobBase
    {
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