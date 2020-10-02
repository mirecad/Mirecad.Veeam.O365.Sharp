namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class PartialOrganizationJobItemBase
    {
        public string Type { get; set; }
        public bool? Mailbox { get; set; }
        public bool? OneDrive { get; set; }
        public bool? ArchiveMailbox { get; set; }
        public bool? Site { get; set; }
        public string Id { get; set; }
    }
}