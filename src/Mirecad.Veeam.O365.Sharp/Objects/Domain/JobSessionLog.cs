using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(JobSessionLogDto))]
    public class JobSessionLog : JobSessionLogDto
    {
        internal VeeamLink<JobSession> LinksJobSessions { get; set; }

        public async Task<JobSession> GetJobSessionAsync(CancellationToken ct = default)
            => await LinksJobSessions.InvokeAsync(ct);
    }
}