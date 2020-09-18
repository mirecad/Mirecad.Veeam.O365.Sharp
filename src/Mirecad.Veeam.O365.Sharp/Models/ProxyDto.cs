using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    public class ProxyDto
    {
        public bool IsDefault { get; set; }
        public bool UseInternetProxy { get; set; }
        public string InternetProxyType { get; set; }
        public string Id { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }
        public int Port { get; set; }
        public int ThreadsNumber { get; set; }
        public bool EnableNetworkThrottling { get; set; }
        public string Status { get; set; }
        
        [JsonProperty("_links")]
        public ProxyLinksDto Links { get; set; }
    }

    public class ProxyLinksDto
    {
        public VeeamLinkDto Repositories { get; set; }
    }
}