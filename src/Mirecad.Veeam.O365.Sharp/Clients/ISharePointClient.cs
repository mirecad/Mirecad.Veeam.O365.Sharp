using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Objects.Domain;

namespace Mirecad.Veeam.O365.Sharp.Clients
{
    public interface ISharePointClient
    {
        Task<VeeamPagedResult<SharePointSite>> GetSharePointSitesAsync(string restoreSessionId,
            string parentSiteId = null,
            int? limit = null,
            int? offset = null,
            CancellationToken ct = default);
    }
}