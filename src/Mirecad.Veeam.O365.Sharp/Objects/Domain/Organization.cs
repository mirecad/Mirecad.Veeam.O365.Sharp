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
        internal VeeamLink<VeeamCollectionResult<Job>> LinksJobs { get; set; }
        internal VeeamLink<VeeamPagedResult<OrganizationGroup>> LinksGroups { get; set; }
        internal VeeamLink<VeeamPagedResult<OrganizationUser>> LinksUsers { get; set; }
        internal VeeamLink<VeeamPagedResult<OrganizationSite>> LinksSites { get; set; }
        internal VeeamLink<VeeamCollectionResult<UsedRepository>> LinksUsedRepositories { get; set; }

        public async Task<VeeamPagedResult<OrganizationUser>> GetUsersAsync(CancellationToken ct = default)
            => await LinksUsers.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetSitesAsync(CancellationToken ct = default)
            => await LinksSites.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationGroup>> GetGroupsAsync(CancellationToken ct = default)
            => await LinksGroups.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<Job>> GetJobsAsync(CancellationToken ct = default)
            => await LinksJobs.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<UsedRepository>> GetUsedRepositoriesAsync(CancellationToken ct = default)
            => await LinksUsedRepositories.InvokeAsync(ct);
    }
}