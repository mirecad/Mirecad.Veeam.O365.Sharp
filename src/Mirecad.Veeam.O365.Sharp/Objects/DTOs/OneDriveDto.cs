using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OneDriveDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        [JsonProperty("_links")]
        internal OneDriveLinksDto Links { get; set; }
    }

    internal class OneDriveLinksDto
    {
        public VeeamLinkDto User { get; set; }
    }
}