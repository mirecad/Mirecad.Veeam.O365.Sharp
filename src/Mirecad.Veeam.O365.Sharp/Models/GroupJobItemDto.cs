
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class GroupJobItemDto
    {
        public string Type { get; set; }
        public OrganizationGroupDto Group { get; set; }
        public bool Members { get; set; }
        public bool MemberMail { get; set; }
        public bool MemberArchive { get; set; }
        public bool MemberOnedrive { get; set; }
        public bool MemberSite { get; set; }
        public bool Mail { get; set; }
        public bool Site { get; set; }
        public string Id { get; set; }

        [JsonProperty("_links")]
        public OrganizationJobItemLinksDto Links { get; set; }
    }

    public class OrganizationJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}