using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Models;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationDto))]
    public class Organization : OrganizationDto
    {
        private readonly IVeeamO365Client _client;

        public Organization(IVeeamO365Client client)
        {
            _client = client;
        }

        public async Task<VeeamPagedResult<OrganizationUser>> GetUsersAsync(CancellationToken ct = default)
            => await _client.OrganizationUsers.GetUsersOfOrganization(Id, ct: ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetSitesAsync(CancellationToken ct = default)
            => await _client.OrganizationSites.GetSitesOfOrganization(Id, ct: ct);

        public async Task<VeeamPagedResult<OrganizationGroup>> GetGroupsAsync(CancellationToken ct = default)
            => await _client.OrganizationGroups.GetGroupsOfOrganization(Id, ct: ct);

        public async Task<VeeamCollectionResult<Job>> GetJobsAsync(CancellationToken ct = default)
            => await _client.Jobs.GetJobsOfOrganization(Id, ct: ct);
    }

    [DataTransferObject(typeof(ExchangeOnlineSettingsDto))]
    public class ExchangeOnlineSettings : ExchangeOnlineSettingsDto
    {
    }

    [DataTransferObject(typeof(SharePointOnlineSettingsDto))]
    public class SharePointOnlineSettings : SharePointOnlineSettingsDto
    {
    }

}