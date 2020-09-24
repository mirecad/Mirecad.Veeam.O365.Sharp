using System;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobSessionDto
    {
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Progress { get; set; }
        public string Status { get; set; }
        public JobSessionStatistics Statistics { get; set; }

        [JsonProperty("_links")]
        internal JobSessionLinksDto Links { get; set; }
    }

    internal class JobSessionLinksDto
    {
        public VeeamLinkDto Log { get; set; }
        public VeeamLinkDto Job { get; set; }
    }
}