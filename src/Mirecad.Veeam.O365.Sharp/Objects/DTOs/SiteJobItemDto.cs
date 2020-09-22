using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class SiteJobItemDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public OrganizationSiteDto Site { get; set; }

        [JsonProperty("_links")]
        internal SiteJobItemLinksDto Links { get; set; }
    }

    internal class SiteJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}