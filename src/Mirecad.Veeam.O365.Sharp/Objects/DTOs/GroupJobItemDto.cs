using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
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
        internal OrganizationJobItemLinksDto Links { get; set; }
    }

    internal class OrganizationJobItemLinksDto
    {
        public VeeamLinkDto Job { get; set; }
    }
}