using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class OneDriveDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        [JsonProperty("_links")]
        public OneDriveLinksDto Links { get; set; }
    }

    public class OneDriveLinksDto
    {
        public VeeamLinkDto User { get; set; }
    }
}