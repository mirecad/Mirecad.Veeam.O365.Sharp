using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationGroupDto : OrganizationGroupBase
    {
        [JsonProperty("_links")]
        internal OrganizationGroupLinks Links { get; set; }
    }

    internal class OrganizationGroupLinks
    {
        public VeeamLinkDto Organization { get; set; }
    }
}