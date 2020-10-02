using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationSiteDto : OrganizationSiteBase
    {
        [JsonProperty("_links")]
        internal OrganizationSiteLinks Links { get; set; }
    }

    internal class OrganizationSiteLinks
    {
        public VeeamLinkDto Children { get; set; }
        public VeeamLinkDto Organization { get; set; }
    }
}