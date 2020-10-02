namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class GroupJobItemBase
    {
        public string Type { get; set; }
        public bool? Members { get; set; }
        public bool? MemberMail { get; set; }
        public bool? MemberArchive { get; set; }
        public bool? MemberOnedrive { get; set; }
        public bool? MemberSite { get; set; }
        public bool? Mail { get; set; }
        public bool? Site { get; set; }
        public string Id { get; set; }
    }
}