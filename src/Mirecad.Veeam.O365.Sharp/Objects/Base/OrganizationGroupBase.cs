namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class OrganizationGroupBase
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string ManagedBy { get; set; }
        public string Site { get; set; }
        public string Type { get; set; }
        public string LocationType { get; set; }
        public bool? IsBackedUp { get; set; }
    }
}