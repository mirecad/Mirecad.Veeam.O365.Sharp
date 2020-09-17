using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(VeeamCollectionResultDto<>))]
    public class VeeamCollectionResult<T> : List<T>
    {
        
    }
}