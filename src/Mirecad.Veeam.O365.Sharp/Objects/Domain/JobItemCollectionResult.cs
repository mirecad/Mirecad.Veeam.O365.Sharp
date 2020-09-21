using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(JobItemCollectionResultDto))]
    public class JobItemCollectionResult
    {
        public List<SiteJobItem> Sites { get; set; } = new List<SiteJobItem>();
        public List<PartialOrganizationJobItem> PartialOrganizations { get; set; } = new List<PartialOrganizationJobItem>();
        public List<UserJobItem> Users { get; set; } = new List<UserJobItem>();
        public List<GroupJobItem> Groups { get; set; } = new List<GroupJobItem>();
    }
}