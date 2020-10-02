using System;

namespace Mirecad.Veeam.O365.Sharp.Objects.Base
{
    public abstract class OneDriveDocumentBase
    {
        public int SizeBytes { get; set; }
        public bool InheritedPermissions { get; set; }
        public string Version { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}