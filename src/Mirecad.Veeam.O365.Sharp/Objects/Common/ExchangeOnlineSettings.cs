namespace Mirecad.Veeam.O365.Sharp.Objects.Common
{
    public class ExchangeOnlineSettings
    {
        public bool UseApplicationOnlyAuth { get; set; }
        public string OfficeOrganizationName { get; set; }
        public string Account { get; set; }
        public bool GrantAdminAccess { get; set; }
        public bool UseMfa { get; set; }
        public string ApplicationId { get; set; }
    }
}