using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OrganizationDto))]
    public class Organization : OrganizationBase
    {
        private VeeamLink<VeeamCollectionResult<Job>> _linksJobs;
        private VeeamLink<VeeamPagedResult<OrganizationGroup>> _linksGroups;
        private VeeamLink<VeeamPagedResult<OrganizationUser>> _linksUsers;
        private VeeamLink<VeeamPagedResult<OrganizationSite>> _linksSites;
        private VeeamLink<VeeamCollectionResult<UsedRepository>> _linksUsedRepositories;

        public async Task<VeeamPagedResult<OrganizationUser>> GetUsersAsync(CancellationToken ct = default)
            => await _linksUsers.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationSite>> GetSitesAsync(CancellationToken ct = default)
            => await _linksSites.InvokeAsync(ct);

        public async Task<VeeamPagedResult<OrganizationGroup>> GetGroupsAsync(CancellationToken ct = default)
            => await _linksGroups.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<Job>> GetJobsAsync(CancellationToken ct = default)
            => await _linksJobs.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<UsedRepository>> GetUsedRepositoriesAsync(CancellationToken ct = default)
            => await _linksUsedRepositories.InvokeAsync(ct);
    }
}