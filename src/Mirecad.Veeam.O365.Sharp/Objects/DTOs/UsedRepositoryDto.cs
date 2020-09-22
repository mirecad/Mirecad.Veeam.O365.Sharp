using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class UsedRepositoryDto
    {
        public long UsedSpaceBytes { get; set; }
        public int LocalCacheUsedSpaceBytes { get; set; }
        public int ObjectStorageUsedSpaceBytes { get; set; }
        public bool IsAvailable { get; set; }
        public string Details { get; set; }

        [JsonProperty("_links")]
        internal UsedRepositoryLinksDto Links { get; set; }
    }

    internal class UsedRepositoryLinksDto
    {
        internal VeeamLinkDto BackupRepository { get; set; }
    }
}