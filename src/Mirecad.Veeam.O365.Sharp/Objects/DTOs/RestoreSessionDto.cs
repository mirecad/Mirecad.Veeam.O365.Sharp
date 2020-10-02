using System;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class RestoreSessionDto : RestoreSessionBase
    {
        [JsonProperty("_links")]
        internal RestoreSessionLinksDto Links { get; set; }
    }

    internal class RestoreSessionLinksDto
    {
        public VeeamLinkDto Organization { get; set; }
        public VeeamLinkDto RestoreSessionEvents { get; set; }
    }
}