using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
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
        internal UserJobItemLinksDto Links { get; set; }
    }

    internal class UserJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}