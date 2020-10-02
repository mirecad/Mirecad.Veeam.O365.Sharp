using System;
using Mirecad.Veeam.O365.Sharp.Objects.Common;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class JobBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastRun { get; set; }
        public DateTime? NextRun { get; set; }
        public bool? IsEnabled { get; set; }
        public string LastStatus { get; set; }
        public SchedulePolicy SchedulePolicy { get; set; }
        public BackupType BackupType { get; set; }
    }
}