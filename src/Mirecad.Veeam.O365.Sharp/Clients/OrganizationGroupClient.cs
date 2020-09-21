using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Models;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class OrganizationGroupClient : IOrganizationGroupClient
    {
        private readonly VeeamO365Client _baseClient;

        public OrganizationGroupClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<OrganizationGroup>> GetGroupsOfOrganization(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            string name = null,
            string groupName = null,
            string displayName = null,
            CancellationToken ct = default
        )
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));

            var parameters = new QueryParameters()
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset)
                .AddOptionalParameter("setId", setId)
                .AddOptionalParameter("name", name)
                .AddOptionalParameter("groupName", groupName)
                .AddOptionalParameter("displayName", displayName);

            var url = $"organizations/{organizationId}/groups";
            return await _baseClient.GetDomainObjectAsync<VeeamPagedResult<OrganizationGroup>>(url, parameters, ct);
        }

        public async Task<OrganizationGroup> GetGroup(string organizationId, string userId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));
            ParameterValidator.ValidateNotNull(userId, nameof(userId));

            var url = $"organizations/{organizationId}/groups/{userId}";
            return await _baseClient.GetDomainObjectAsync<OrganizationGroup>(url, null, ct);
        }
    }
}