namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class OrganizationUserBase
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? IsBackedUp { get; set; }
    }
}