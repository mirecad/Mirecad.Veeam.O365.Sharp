using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OneDriveDto : OneDriveBase
    {
        [JsonProperty("_links")]
        internal OneDriveLinksDto Links { get; set; }
    }

    internal class OneDriveLinksDto
    {
        public VeeamLinkDto User { get; set; }
    }
}