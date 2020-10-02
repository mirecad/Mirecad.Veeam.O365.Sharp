using System;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract  class RestoreSessionBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Type { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
        public string State { get; set; }
        public string Result { get; set; }
        public string InitiatedBy { get; set; }
    }
}