using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(VeeamPagedResultDto<object>))]
    public class VeeamPagedResult<T> where T : class
    {
        private VeeamLink<VeeamPagedResult<T>> _linksFirst;
        private VeeamLink<VeeamPagedResult<T>> _linksPrevious;
        private VeeamLink<VeeamPagedResult<T>> _linksNext;

        public int Offset { get; set; }
        public int Limit { get; set; }
        public IEnumerable<T> Results { get; set; }

        public async Task<VeeamPagedResult<T>> GetFirstPageAsync(CancellationToken ct = default)
        {
            if (_linksFirst == null)
            {
                throw new InvalidOperationException("First page is not available.");
            }

            return await _linksFirst.InvokeAsync(ct);
        }

        public async Task<VeeamPagedResult<T>> GetPreviousPageAsync(CancellationToken ct = default)
        {
            if (_linksPrevious == null)
            {
                throw new InvalidOperationException("Previous page is not available.");
            }

            return await _linksPrevious.InvokeAsync(ct);
        }

        public async Task<VeeamPagedResult<T>> GetNextPageAsync(CancellationToken ct = default)
        {
            if (_linksNext == null)
            {
                throw new InvalidOperationException("Next page is not available.");
            }

            return await _linksNext.InvokeAsync(ct);
        }
    }
}