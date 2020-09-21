using System;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(VeeamLinkDto))]
    public class VeeamLink<T> where T : class
    {
        private readonly VeeamO365Client _client;

        public string Href { get; set; }

        public VeeamLink(VeeamO365Client client)
        {
            _client = client;
        }

        public async Task<T> InvokeAsync(CancellationToken ct)
        {
            if (_client == null)
            {
                throw new ObjectDisposedException(nameof(VeeamO365Client));
            }

            if (string.IsNullOrEmpty(Href))
            {
                throw new InvalidOperationException("Uri for this link was not provided.");
            }

            return await _client.GetDomainObjectByFullUrlAsync<T>(Href, ct);
        }
    }
}