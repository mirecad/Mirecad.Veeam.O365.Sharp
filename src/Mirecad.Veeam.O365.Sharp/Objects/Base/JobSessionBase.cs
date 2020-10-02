using System;
using Mirecad.Veeam.O365.Sharp.Objects.Common;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class JobSessionBase
    {
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Progress { get; set; }
        public string Status { get; set; }
        public JobSessionStatistics Statistics { get; set; }
    }
}