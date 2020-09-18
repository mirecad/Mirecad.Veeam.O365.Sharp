using System;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(JobSessionDto))]
    public class JobSession
    {
        private VeeamLink<Job> _linksJob;
        private VeeamLink<VeeamPagedResult<JobSessionLog>> _linksLog;

        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; }
        public JobSessionStatistics Statistics { get; set; }

        public async Task<Job> GetJobAsync(CancellationToken ct = default)
            => await _linksJob.InvokeAsync(ct);

        public async Task<VeeamPagedResult<JobSessionLog>> GetLogsAsync(CancellationToken ct = default)
            => await _linksLog.InvokeAsync(ct);
    }

    [DataTransferObject(typeof(JobSessionStatisticsDto))]
    public class JobSessionStatistics
    {
        public int ProcessingRateBytesPs { get; set; }
        public int ProcessingRateItemsPs { get; set; }
        public int ReadRateBytesPs { get; set; }
        public int WriteRateBytesPs { get; set; }
        public int TransferredDataBytes { get; set; }
        public int ProcessedObjects { get; set; }
        public string Bottleneck { get; set; }
    }
}