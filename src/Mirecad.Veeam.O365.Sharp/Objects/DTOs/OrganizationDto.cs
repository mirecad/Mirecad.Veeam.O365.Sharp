using System;
using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OrganizationDto
    {
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
        public SharePointOnlineSettings SharePointOnlineSettings  { get; set; }

        [JsonProperty("_links")]
        internal OrganizationLinksDto Links { get; set; }
    }
    public class ExchangeOnlineSettings
    {
        public bool UseApplicationOnlyAuth { get; set; }
        public string OfficeOrganizationName { get; set; }
        public string Account { get; set; }
        public bool GrantAdminAccess { get; set; }
        public bool UseMfa { get; set; }
        public string ApplicationId { get; set; }
    }

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

    internal class OrganizationLinksDto
    {
        public VeeamLinkDto Jobs { get; set; }
        public VeeamLinkDto Groups { get; set; }
        public VeeamLinkDto Users { get; set; }
        public VeeamLinkDto Sites { get; set; }
        public VeeamLinkDto UsedRepositories { get; set; }
    }
}