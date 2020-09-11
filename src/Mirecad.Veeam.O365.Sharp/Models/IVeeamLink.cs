using System.Threading;
using System.Threading.Tasks;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public interface IVeeamLink<T> where T : class
    {
        Task<T> InvokeAsync(CancellationToken ct);
    }
}