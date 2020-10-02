using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class GroupJobItemDto : GroupJobItemBase
    {
        public virtual OrganizationGroupDto Group { get; set; }

        [JsonProperty("_links")]
        internal OrganizationJobItemLinksDto Links { get; set; }
    }

    internal class OrganizationJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}