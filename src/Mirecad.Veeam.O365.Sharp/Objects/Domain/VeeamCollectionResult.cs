using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(VeeamCollectionResultDto<>))]
    public class VeeamCollectionResult<T> : List<T>
    {
    }
}