using System;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class RestoreSessionEventBase
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Duration { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Order { get; set; }
    }
}