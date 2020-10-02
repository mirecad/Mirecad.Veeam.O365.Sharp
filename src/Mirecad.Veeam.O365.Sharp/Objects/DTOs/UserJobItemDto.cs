using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class UserJobItemDto : UserJobItemBase
    {
        public OrganizationUserDto User { get; set; }

        [JsonProperty("_links")]
        internal UserJobItemLinksDto Links { get; set; }
    }

    internal class UserJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}