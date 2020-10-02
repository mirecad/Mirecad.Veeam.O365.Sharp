using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public class OrganizationClient : IOrganizationClient
    {
        private readonly VeeamO365Client _baseClient;

        public OrganizationClient(VeeamO365Client baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<VeeamCollectionResult<Organization>> GetOrganizationsAsync(CancellationToken ct = default)
        {
            var url = "organizations";
            return await _baseClient.GetAsync<VeeamCollectionResult<Organization>>(url, null, ct);
        }
    }
}