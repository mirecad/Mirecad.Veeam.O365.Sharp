using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationSiteDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool IsCloud { get; set; }
        public bool IsPersonal { get; set; }
        public string Title { get; set; }
        public bool IsBackedUp { get; set; }
        public bool IsAvailable { get; set; }

        [JsonProperty("_links")]
        internal OrganizationSiteLinks Links { get; set; }
    }

    internal class OrganizationSiteLinks
    {
        public VeeamLinkDto Children { get; set; }
        public VeeamLinkDto Organization { get; set; }
    }
}