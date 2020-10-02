using System;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class JobSessionLogBase
    {
        public string Id { get; set; }
        public int? Usn { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}