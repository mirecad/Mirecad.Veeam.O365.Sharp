using System;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobSessionLogDto : JobSessionLogBase
    {
        [JsonProperty("_links")]
        internal JobSessionLogLinksDto Links { get; set; }
    }

    internal class JobSessionLogLinksDto
    {
        public VeeamLinkDto JobSessions { get; set; }
    }
}