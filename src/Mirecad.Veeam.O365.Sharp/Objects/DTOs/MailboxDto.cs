using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class MailboxDto : MailboxBase
    {
        [JsonProperty("_links")]
        internal MailboxLinksDto Links { get; set; }
    }

    internal class MailboxLinksDto
    {
        public VeeamLinkDto Folders { get; set; }
        public VeeamLinkDto AllFolders { get; set; }
        public VeeamLinkDto Items { get; set; }
    }
}