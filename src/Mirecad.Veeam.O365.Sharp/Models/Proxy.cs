using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(ProxyDto))]
    public class Proxy
    {
        private VeeamLink<VeeamCollectionResult<BackupRepository>> _linksRepositories;

        public bool IsDefault { get; set; }
        public bool UseInternetProxy { get; set; }
        public string InternetProxyType { get; set; }
        public string Id { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }
        public int Port { get; set; }
        public int ThreadsNumber { get; set; }
        public bool EnableNetworkThrottling { get; set; }
        public string Status { get; set; }

        public async Task<VeeamCollectionResult<BackupRepository>> GetBackupRepositoriesAsync(CancellationToken ct = default)
            => await _linksRepositories.InvokeAsync(ct);
    }
}