namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class OrganizationSiteBase
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool? IsCloud { get; set; }
        public bool? IsPersonal { get; set; }
        public string Title { get; set; }
        public bool? IsBackedUp { get; set; }
        public bool? IsAvailable { get; set; }
    }
}