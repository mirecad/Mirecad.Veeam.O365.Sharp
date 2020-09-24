namespace Mirecad.Veeam.O365.Sharp.Objects.Common
{
    public class BackupWindowSettings
    {
        public BackupWindowSettings()
        {
            BackupWindow = new bool[168];
        }

        public bool[] BackupWindow { get; set; }
        public int? MinuteOffset { get; set; }
    }
}