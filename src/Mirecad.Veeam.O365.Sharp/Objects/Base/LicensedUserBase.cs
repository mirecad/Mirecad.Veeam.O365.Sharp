using System;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class LicensedUserBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsBackedUp { get; set; }
        public DateTime LastBackupDate { get; set; }
        public string LicenseState { get; set; }
        public string OrganizationId { get; set; }
        public string BackedUpOrganizationId { get; set; }
        public string OrganizationName { get; set; }
    }
}