using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(SiteJobItemDto))]
    public class SiteJobItem
    {
        private VeeamLink<Job> _linksJob;

        public string Id { get; set; }
        public string Type { get; set; }
        public OrganizationSite Site { get; set; }

        public async Task<Job> GetJobAsync(CancellationToken ct = default)
            => await _linksJob.InvokeAsync(ct);
    }
}