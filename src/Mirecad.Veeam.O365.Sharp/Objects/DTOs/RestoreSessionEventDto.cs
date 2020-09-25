using System;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class RestoreSessionEventDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Duration { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Order { get; set; }

        [JsonProperty("_links")]
        internal RestoreSessionEventLinksDto Links { get; set; }
    }

    internal class RestoreSessionEventLinksDto
    {
        public VeeamLinkDto RestoreSession { get; set; }
    }
}