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
        internal VeeamLink<VeeamPagedResult<T>> LinksFirst { get; set; }
        internal VeeamLink<VeeamPagedResult<T>> LinksPrevious { get; set; }
        internal VeeamLink<VeeamPagedResult<T>> LinksNext { get; set; }

        public int Offset { get; set; }
        public int Limit { get; set; }
        public IEnumerable<T> Results { get; set; }

        public async Task<VeeamPagedResult<T>> GetFirstPageAsync(CancellationToken ct = default)
        {
            if (LinksFirst == null)
            {
                throw new InvalidOperationException("First page is not available.");
            }

            return await LinksFirst.InvokeAsync(ct);
        }

        public async Task<VeeamPagedResult<T>> GetPreviousPageAsync(CancellationToken ct = default)
        {
            if (LinksPrevious == null)
            {
                throw new InvalidOperationException("Previous page is not available.");
            }

            return await LinksPrevious.InvokeAsync(ct);
        }

        public async Task<VeeamPagedResult<T>> GetNextPageAsync(CancellationToken ct = default)
        {
            if (LinksNext == null)
            {
                throw new InvalidOperationException("Next page is not available.");
            }

            return await LinksNext.InvokeAsync(ct);
        }
    }
}