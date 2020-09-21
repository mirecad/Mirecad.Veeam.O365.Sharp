using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class SiteJobItemDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public OrganizationSiteDto Site { get; set; }

        [JsonProperty("_links")]
        public SiteJobItemLinksDto Links { get; set; }
    }

    public class SiteJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}