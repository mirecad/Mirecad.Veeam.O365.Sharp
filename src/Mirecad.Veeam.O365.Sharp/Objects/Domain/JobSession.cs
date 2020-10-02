using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(JobSessionDto))]
    public class JobSession : JobSessionBase
    {
        private VeeamLink<Job> _linksJob;
        private VeeamLink<VeeamPagedResult<JobSessionLog>> _linksLog;

        public async Task<Job> GetJobAsync(CancellationToken ct = default)
            => await _linksJob.InvokeAsync(ct);

        public async Task<VeeamPagedResult<JobSessionLog>> GetLogsAsync(CancellationToken ct = default)
            => await _linksLog.InvokeAsync(ct);
    }
}