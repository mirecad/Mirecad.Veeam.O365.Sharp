﻿using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class OrganizationUserClient : IOrganizationUserClient
    {
        private readonly VeeamO365Client _baseClient;

        public OrganizationUserClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<OrganizationUser>> GetUsersOfOrganizationAsync(string organizationId,
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
            return await _baseClient.GetAsync<VeeamPagedResult<OrganizationUser>>(url, parameters, ct);
        }

        public async Task<OrganizationUser> GetUserAsync(string organizationId, string userId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(organizationId, nameof(organizationId));
            ParameterValidator.ValidateNotNull(userId, nameof(userId));

            var url = $"organizations/{organizationId}/users/{userId}";
            return await _baseClient.GetAsync<OrganizationUser>(url, null, ct);
        }
    }
}