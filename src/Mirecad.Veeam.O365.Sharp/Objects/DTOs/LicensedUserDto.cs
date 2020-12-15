using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class LicensedUserDto : LicensedUserBase
    {
        [JsonProperty("_links")]
        internal LicensedUserLinksDto Links { get; set; }
    }

    internal class LicensedUserLinksDto
    {
        public VeeamLinkDto Organization { get; set; }
    }
}