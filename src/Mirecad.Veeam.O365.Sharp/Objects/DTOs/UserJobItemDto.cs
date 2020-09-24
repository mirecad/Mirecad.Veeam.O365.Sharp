using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{

    public class UserJobItemBase
    {
        public string Type { get; set; }
        public bool? Mailbox { get; set; }
        public bool? OneDrive { get; set; }
        public bool? ArchiveMailbox { get; set; }
        public bool? Site { get; set; }
        public string Id { get; set; }
    }

    public class UserJobItemDto : UserJobItemBase
    {
        public OrganizationUserDto User { get; set; }

        [JsonProperty("_links")]
        internal UserJobItemLinksDto Links { get; set; }
    }

    internal class UserJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}