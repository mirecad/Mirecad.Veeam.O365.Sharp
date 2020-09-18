using System;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class JobSessionLogDto
    {
        public string Id { get; set; }
        public int Usn { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }

        [JsonProperty("_links")]
        public JobSessionLogLinksDto Links { get; set; }
    }

    public class JobSessionLogLinksDto
    {
        public VeeamLinkDto JobSessions { get; set; }
    }
}