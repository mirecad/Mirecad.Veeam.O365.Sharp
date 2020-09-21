using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class UserJobItemDto
    {
        public string Type { get; set; }
        public OrganizationUserDto User { get; set; }
        public bool Mailbox { get; set; }
        public bool OneDrive { get; set; }
        public bool ArchiveMailbox { get; set; }
        public bool Site { get; set; }
        public string Id { get; set; }

        [JsonProperty("_links")]
        public UserJobItemLinksDto Links { get; set; }
    }

    public class UserJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}