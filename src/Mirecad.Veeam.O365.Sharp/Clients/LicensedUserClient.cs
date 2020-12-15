using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class LicensedUserClient : ILicensedUserClient
    {
        private readonly VeeamO365Client _baseClient;

        public LicensedUserClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamPagedResult<LicensedUser>> GetLicensedUsersAsync(string organizationId = null,
            string name = null,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default)
        {
            var parameters = new QueryParameters()
                .AddOptionalParameter("organizationId", organizationId)
                .AddOptionalParameter("name", name)
                .AddOptionalParameter("limit", limit)
                .AddOptionalParameter("offset", offset);

            var url = "licensedusers";
            return await _baseClient.GetAsync<VeeamPagedResult<LicensedUser>>(url, parameters, ct);
        }

        public async Task RevokeLicenseFromUserAsync(string licensedUserId, CancellationToken ct = default)
        {
            ParameterValidator.ValidateNotNull(licensedUserId, nameof(licensedUserId));

            var url = $"licensedusers/{licensedUserId}";
            await _baseClient.DeleteAsync(url, null, ct);
        }
    }
}