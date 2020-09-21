using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(PartialOrganizationJobItemDto))]
    public class PartialOrganizationJobItem
    {
        public string Type { get; set; }
        public bool Mailbox { get; set; }
        public bool OneDrive { get; set; }
        public bool ArchiveMailbox { get; set; }
        public bool Site { get; set; }
        public string Id { get; set; }
    }
}