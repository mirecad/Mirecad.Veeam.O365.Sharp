using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class BackupRepositoryDto : BackupRepositoryBase
    {
        [JsonProperty("_links")]
        internal BackupRepositoryLinksDto Links { get; set; }
    }

    internal class BackupRepositoryLinksDto
    {
        public VeeamLinkDto Proxy { get; set; }
    }
}