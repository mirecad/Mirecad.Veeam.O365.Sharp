using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(GroupJobItemDto))]
    public class GroupJobItem
    {
        private VeeamLink<Job> _linksJob;

        public string Type { get; set; }
        public OrganizationGroup Group { get; set; }
        public bool Members { get; set; }
        public bool MemberMail { get; set; }
        public bool MemberArchive { get; set; }
        public bool MemberOnedrive { get; set; }
        public bool MemberSite { get; set; }
        public bool Mail { get; set; }
        public bool Site { get; set; }
        public string Id { get; set; }

        public async Task<Job> GetJobAsync(CancellationToken ct = default)
            => await _linksJob.InvokeAsync(ct);
    }
}