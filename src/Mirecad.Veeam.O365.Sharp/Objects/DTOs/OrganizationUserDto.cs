using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationUserDto : OrganizationUserBase
    {
        [JsonProperty("_links")]
        internal UserLinksDto Links { get; set; }
    }

    internal class UserLinksDto    
    {
        public VeeamLinkDto Organization { get; set; }
        public VeeamLinkDto OneDrives { get; set; }
    }
}