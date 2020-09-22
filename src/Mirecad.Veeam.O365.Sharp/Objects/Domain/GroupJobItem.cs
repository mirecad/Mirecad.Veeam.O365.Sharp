using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(GroupJobItemDto))]
    public class GroupJobItem : GroupJobItemDto
    {
        internal VeeamLink<Job> LinksJob { get; set; }

        public async Task<Job> GetJobAsync(CancellationToken ct = default)
            => await LinksJob.InvokeAsync(ct);
    }
}