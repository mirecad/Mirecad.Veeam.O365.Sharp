using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(JobDto))]
    public class Job
    {
        //TODO: create object for links
        private VeeamLink<Organization> _linksOrganization;
        //private VeeamLink<BackupRepository> _linksBackupRepository;
        //private VeeamLink<JobSessions> _linksJobSessions;
        //private VeeamLink<Items> _linksExcludedItems;
        //private VeeamLink<Items> _linksSelectedItems;

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsBackedUp { get; set; }

        public async Task<Organization> GetOrganizationAsync(CancellationToken ct = default)
            => await _linksOrganization.InvokeAsync(ct);
    }
}