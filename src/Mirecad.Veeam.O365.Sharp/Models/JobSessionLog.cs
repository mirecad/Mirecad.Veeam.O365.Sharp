using System;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(JobSessionLogDto))]
    public class JobSessionLog
    {
        private VeeamLink<JobSession> _linksJobSessions;

        public string Id { get; set; }
        public int Usn { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }

        public async Task<JobSession> GetJobSessionAsync(CancellationToken ct = default)
            => await _linksJobSessions.InvokeAsync(ct);
    }
}