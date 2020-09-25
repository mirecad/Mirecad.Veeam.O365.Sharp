using System;
using Mirecad.Veeam.O365.Sharp.Objects.Enums;

namespace Mirecad.Veeam.O365.Sharp.Objects.Common
{
    public class RestoreSessionExploreDetails
    {
        public RestoreSessionExploreDetails(DateTime dateTime, RestoreSessionType type, bool showDeleted, bool showAllVersions)
        {
            DateTime = dateTime;
            Type = type;
            ShowDeleted = showDeleted;
            ShowAllVersions = showAllVersions;
        }

        public DateTime DateTime { get; }
        public RestoreSessionType Type { get; }
        public bool ShowDeleted { get; }
        public bool ShowAllVersions { get; }
    }
}