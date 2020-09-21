using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Converters;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [JsonConverter(typeof(JobItemCollectionConverter))]
    public class JobItemCollectionResultDto
    {
        public List<SiteJobItemDto> Sites { get; set; } = new List<SiteJobItemDto>();
        public List<PartialOrganizationJobItemDto> PartialOrganizations { get; set; } = new List<PartialOrganizationJobItemDto>();
        public List<UserJobItemDto> Users { get; set; } = new List<UserJobItemDto>();
        public List<GroupJobItemDto> Groups { get; set; } = new List<GroupJobItemDto>();
    }
}