using System;
using Mirecad.Veeam.O365.Sharp.Objects.Common;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class OrganizationBase
    {
        public string Type { get; set; }
        public string Region { get; set; }
        public bool? IsExchangeOnline { get; set; }
        public bool? IsSharePointOnline { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string OfficeName { get; set; }
        public bool? IsBackedUp { get; set; }
        public DateTime? FirstBackupTime { get; set; }
        public DateTime? LastBackupTime { get; set; }
        public ExchangeOnlineSettings ExchangeOnlineSettings { get; set; }
        public SharePointOnlineSettings SharePointOnlineSettings { get; set; }
    }
}