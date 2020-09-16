using System;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(OrganizationDto))]
    public class Organization
    {
        //TODO:Implement organization links
        //private VeeamLink<VeeamPagedResultDto<Job>> _linksJobs;
        //private VeeamLink<VeeamPagedResultDto<Group>> _linksGroups;
        private VeeamLink<VeeamPagedResultDto<User>> _linksUsers;
        //private VeeamLink<VeeamPagedResultDto<Site>> _linksSites;

        public string Type { get; set; }
        public string Region { get; set; }
        public bool IsExchangeOnline { get; set; }
        public bool IsSharePointOnline { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string OfficeName { get; set; }
        public bool IsBackedUp { get; set; }
        public DateTime? FirstBackupTime { get; set; }
        public DateTime? LastBackupTime { get; set; }
        public ExchangeOnlineSettings ExchangeOnlineSettings { get; set; }
        public SharePointOnlineSettings SharePointOnlineSettings { get; set; }
    }

    [DataTransferObject(typeof(ExchangeOnlineSettingsDto))]
    public class ExchangeOnlineSettings
    {
        public bool UseApplicationOnlyAuth { get; set; }
        public string OfficeOrganizationName { get; set; }
        public string Account { get; set; }
        public bool GrantAdminAccess { get; set; }
        public bool UseMfa { get; set; }
        public string ApplicationId { get; set; }
    }

    [DataTransferObject(typeof(SharePointOnlineSettingsDto))]
    public class SharePointOnlineSettings
    {
        public bool UseApplicationOnlyAuth { get; set; }
        public string OfficeOrganizationName { get; set; }
        public bool SharePointSaveAllWebParts { get; set; }
        public string Account { get; set; }
        public bool GrantAdminAccess { get; set; }
        public bool UseMfa { get; set; }
        public string ApplicationId { get; set; }
    }

}