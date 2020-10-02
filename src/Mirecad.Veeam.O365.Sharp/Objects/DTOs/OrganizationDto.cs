using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationDto : OrganizationBase
    {
        [JsonProperty("_links")]
        internal OrganizationLinksDto Links { get; set; }
    }

    internal class OrganizationLinksDto
    {
        public VeeamLinkDto Jobs { get; set; }
        public VeeamLinkDto Groups { get; set; }
        public VeeamLinkDto Users { get; set; }
        public VeeamLinkDto Sites { get; set; }
        public VeeamLinkDto UsedRepositories { get; set; }
    }
}