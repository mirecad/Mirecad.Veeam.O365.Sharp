using Mirecad.Veeam.O365.Sharp.Objects.Base;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class UsedRepositoryDto : UsedRepositoryBase
    {
        [JsonProperty("_links")]
        internal UsedRepositoryLinksDto Links { get; set; }
    }

    internal class UsedRepositoryLinksDto
    {
        internal VeeamLinkDto BackupRepository { get; set; }
    }
}