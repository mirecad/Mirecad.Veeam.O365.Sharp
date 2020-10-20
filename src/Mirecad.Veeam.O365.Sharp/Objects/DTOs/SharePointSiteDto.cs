using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class SharePointSiteDto : SharePointSiteBase
    {
        [JsonProperty("_links")]
        internal SharePointSiteLinksDto Links { get; set; }
    }

    internal class SharePointSiteLinksDto
    {
    }
}