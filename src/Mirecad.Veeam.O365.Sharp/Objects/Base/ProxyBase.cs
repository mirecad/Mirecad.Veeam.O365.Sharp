namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class ProxyBase
    {
        public bool? IsDefault { get; set; }
        public bool? UseInternetProxy { get; set; }
        public string InternetProxyType { get; set; }
        public string Id { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }
        public int? Port { get; set; }
        public int? ThreadsNumber { get; set; }
        public bool? EnableNetworkThrottling { get; set; }
        public string Status { get; set; }
    }
}