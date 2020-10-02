using System;
using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class OneDriveFolderDto : OneDriveFolderBase
    {
        [JsonProperty("_links")]
        internal OneDriveFolderLinksDto Links { get; set; }
    }

    internal class OneDriveFolderLinksDto   
    {
        public VeeamLinkDto OneDrive { get; set; }
        public VeeamLinkDto Parent { get; set; }
        public VeeamLinkDto Folders { get; set; }
        public VeeamLinkDto Documents { get; set; }
    }
}