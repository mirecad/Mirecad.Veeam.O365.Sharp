using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class UsedRepositoryDto
    {
        public long UsedSpaceBytes { get; set; }
        public int LocalCacheUsedSpaceBytes { get; set; }
        public int ObjectStorageUsedSpaceBytes { get; set; }
        public bool IsAvailable { get; set; }
        public string Details { get; set; }

        [JsonProperty("_links")]
        public UsedRepositoryLinksDto Links { get; set; }
    }

    public class UsedRepositoryLinksDto
    {
        public VeeamLinkDto BackupRepository { get; set; }
    }
}