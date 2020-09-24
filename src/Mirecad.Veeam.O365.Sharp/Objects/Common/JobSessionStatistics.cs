namespace Mirecad.Veeam.O365.Sharp.Objects.Common
{
    public class JobSessionStatistics
    {
        public int? ProcessingRateBytesPs { get; set; }
        public int? ProcessingRateItemsPs { get; set; }
        public int? ReadRateBytesPs { get; set; }
        public int? WriteRateBytesPs { get; set; }
        public int? TransferredDataBytes { get; set; }
        public int? ProcessedObjects { get; set; }
        public string Bottleneck { get; set; }
    }
}