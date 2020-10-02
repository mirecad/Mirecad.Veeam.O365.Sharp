using System;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class RestoreSessionEventDto : RestoreSessionEventBase
    {
        [JsonProperty("_links")]
        internal RestoreSessionEventLinksDto Links { get; set; }
    }

    internal class RestoreSessionEventLinksDto
    {
        public VeeamLinkDto RestoreSession { get; set; }
    }
}