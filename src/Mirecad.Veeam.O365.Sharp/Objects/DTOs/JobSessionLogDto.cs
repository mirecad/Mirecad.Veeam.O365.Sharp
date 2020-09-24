using System;
using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobSessionLogDto
    {
        public string Id { get; set; }
        public int Usn { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }

        [JsonProperty("_links")]
        internal JobSessionLogLinksDto Links { get; set; }
    }

    internal class JobSessionLogLinksDto
    {
        public VeeamLinkDto JobSessions { get; set; }
    }
}