using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Models;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class OrganizationClient : IOrganizationClient
    {
        private readonly VeeamO365Client _baseClient;

        public OrganizationClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamListResult<Organization>> GetOrganizations(CancellationToken ct = default)
        {
            var url = "organizations";
            return await _baseClient.GetDomainObjectAsync<VeeamListResult<Organization>>(url, null, ct);
        }

        public async Task<VeeamPagedResult<User>> GetUsersOfOrganization(string organizationId,
            int? limit = null,
            int? offset = null,
            string setId = null,
            string name = null,
            string userName = null,
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
                .AddOptionalParameter("userName", userName)
                .AddOptionalParameter("displayName", displayName);

            var url = $"organizations/{organizationId}/users";
            return await _baseClient.GetDomainObjectAsync<VeeamPagedResult<User>>(url, parameters, ct);
        }
    }
}