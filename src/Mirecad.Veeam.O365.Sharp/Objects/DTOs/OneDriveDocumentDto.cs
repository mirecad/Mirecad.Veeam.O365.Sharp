using System;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OneDriveDocumentDto : OneDriveDocumentBase
    {
        [JsonProperty("_links")]
        internal OneDriveDocumentLinksDto Links { get; set; }
    }

    internal class OneDriveDocumentLinksDto
    {
        public VeeamLinkDto OneDrive { get; set; }
        public VeeamLinkDto Parent { get; set; }
    }
}