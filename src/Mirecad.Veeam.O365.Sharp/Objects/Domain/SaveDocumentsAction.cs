using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(SaveDocumentsActionDto))]
    public class SaveDocumentsAction : SaveDocumentsActionBase
    {
        public List<OneDriveDocument> Documents { get; set; }
    }
}