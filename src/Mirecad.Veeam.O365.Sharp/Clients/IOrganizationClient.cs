using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Models;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface IOrganizationClient
    {
        Task<VeeamCollectionResult<Organization>> GetOrganizations(CancellationToken ct = default);
    }
}