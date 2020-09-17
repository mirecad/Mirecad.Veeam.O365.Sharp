using System;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(OrganizationDto))]
    public class Organization
    {
        //TODO:Implement organization links
        //private VeeamLink<VeeamPagedResult<Job>> _linksJobs;
        private VeeamLink<VeeamPagedResult<OrganizationGroup>> _linksGroups;
        private VeeamLink<VeeamPagedResult<OrganizationUser>> _linksUsers;
        private VeeamLink<VeeamPagedResult<OrganizationSite>> _linksSites;

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

        public async Task<VeeamPagedResult<OrganizationUser>> GetUsersAsync(CancellationToken ct = default)
            => await _linksUsers.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetSitesAsync(CancellationToken ct = default)
            => await _linksSites.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationGroup>> GetGroupsAsync(CancellationToken ct = default)
            => await _linksGroups.InvokeAsync(ct);
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