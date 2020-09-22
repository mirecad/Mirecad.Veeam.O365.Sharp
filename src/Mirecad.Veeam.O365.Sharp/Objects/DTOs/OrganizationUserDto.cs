using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationUserDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type  { get; set; }
        public bool IsBackedUp { get; set; }

        [JsonProperty("_links")]
        internal UserLinksDto Links { get; set; }
    }

    internal class UserLinksDto    
    {
        public VeeamLinkDto Organization { get; set; }
        public VeeamLinkDto OneDrives { get; set; }
    }
}