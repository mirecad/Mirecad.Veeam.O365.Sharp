namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class UsedRepositoryBase
    {
        public long? UsedSpaceBytes { get; set; }
        public int? LocalCacheUsedSpaceBytes { get; set; }
        public int? ObjectStorageUsedSpaceBytes { get; set; }
        public bool? IsAvailable { get; set; }
        public string Details { get; set; }
    }
}