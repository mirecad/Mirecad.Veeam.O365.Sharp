using System;
using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OneDriveDocumentDto))]
    public class OneDriveDocument : OneDriveDocumentBase
    {
        private VeeamLink<OneDrive> _linksOneDrive;
        private VeeamLink<OneDriveFolder> _linksParent;
        
        public async Task<OneDrive> GetOneDriveAsync(CancellationToken ct = default)
            => await _linksOneDrive.InvokeAsync(ct);

        public async Task<OneDriveFolder> GetParentAsync(CancellationToken ct = default)
            => await _linksParent.InvokeAsync(ct);


    }
}