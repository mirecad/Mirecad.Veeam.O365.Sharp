using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class JobSessionDto : JobSessionBase
    {
        [JsonProperty("_links")]
        internal JobSessionLinksDto Links { get; set; }
    }

    internal class JobSessionLinksDto
    {
        public VeeamLinkDto Log { get; set; }
        public VeeamLinkDto Job { get; set; }
    }
}