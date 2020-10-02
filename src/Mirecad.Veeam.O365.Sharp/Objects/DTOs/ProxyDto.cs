using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class ProxyDto : ProxyBase
    {
        [JsonProperty("_links")]
        internal ProxyLinksDto Links { get; set; }
    }

    internal class ProxyLinksDto
    {
        public VeeamLinkDto Repositories { get; set; }
    }
}