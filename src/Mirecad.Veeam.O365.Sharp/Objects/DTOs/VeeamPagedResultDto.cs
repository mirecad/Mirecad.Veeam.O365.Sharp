using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirecad.Veeam.O365.Sharp.Objects.DTOs
{
    public class VeeamPagedResultDto<T> where T : class
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public IEnumerable<T> Results { get; set; }

        [JsonIgnore]
        [JsonProperty("_links")]
        internal VeeamPagedResultLinksDto Links { get; set; }
    }

    internal class VeeamPagedResultLinksDto
    {
        public VeeamLinkDto First { get; set; }

        [JsonProperty("prev")]
        public VeeamLinkDto Previous { get; set; }
        
        public VeeamLinkDto Self { get; set; }
        
        public VeeamLinkDto Next { get; set; }
    }
}