using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(OneDriveFolderDto))]
    public class OneDriveFolder : OneDriveFolderBase
    {
        private VeeamLink<OneDrive> _linksOneDrive;
        private VeeamLink<OneDriveFolder> _linksParent;
        private VeeamLink<VeeamCollectionResult<OneDriveFolder>> _linksFolders;
        private VeeamLink<VeeamCollectionResult<OneDriveDocument>> _linksDocuments;

        public async Task<OneDrive> GetOneDriveAsync(CancellationToken ct = default)
            => await _linksOneDrive.InvokeAsync(ct);

        public async Task<OneDriveFolder> GetParentAsync(CancellationToken ct = default)
            => await _linksParent.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<OneDriveFolder>> GetFoldersAsync(CancellationToken ct = default)
            => await _linksFolders.InvokeAsync(ct);

        public async Task<VeeamCollectionResult<OneDriveDocument>> GetDocumentsAsync(CancellationToken ct = default)
            => await _linksDocuments.InvokeAsync(ct);
    }
}