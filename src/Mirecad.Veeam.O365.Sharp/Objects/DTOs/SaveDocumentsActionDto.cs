using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Objects.Base;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class SaveDocumentsActionDto : SaveDocumentsActionBase
    {
        public List<OneDriveDocumentDto> Documents { get; set; }
    }
}