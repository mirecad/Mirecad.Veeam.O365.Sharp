using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(UserJobItemDto))]
    public class UserJobItem
    {
        private VeeamLink<Job> _linksJob;

        public string Type { get; set; }
        public OrganizationUser User { get; set; }
        public bool Mailbox { get; set; }
        public bool OneDrive { get; set; }
        public bool ArchiveMailbox { get; set; }
        public bool Site { get; set; }
        public string Id { get; set; }

        public async Task<Job> GetJobAsync(CancellationToken ct = default)
            => await _linksJob.InvokeAsync(ct);
    }
}