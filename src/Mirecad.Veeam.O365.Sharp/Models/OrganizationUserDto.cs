using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class OrganizationUserDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type  { get; set; }
        public bool IsBackedUp { get; set; }

        [JsonProperty("_links")]
        public UserLinksDto Links { get; set; }
    }

    public class UserLinksDto    
    {
        public VeeamLinkDto Organization { get; set; }
        public VeeamLinkDto OneDrives { get; set; }
    }
}