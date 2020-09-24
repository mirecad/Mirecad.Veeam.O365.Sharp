using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(BackupRepositoryDto))]
    public class BackupRepository : BackupRepositoryDto
    {
        private VeeamLink<Proxy> _linksProxy { get; set; }
        
        public async Task<Proxy> GetProxyAsync(CancellationToken ct = default)
            => await _linksProxy.InvokeAsync(ct);
    }
}