using System;

namespace WebCLI.Domain.Models
{
    public class HardDriveInfo
    {
        public HardDriveInfo(string diskName, long freeSpaceInBytes, long totalSizeInBytes)
        {
            DiskName = diskName;
            FreeSpace = FormatBytes(freeSpaceInBytes);
            TotalSize = FormatBytes(totalSizeInBytes);
        }

        public string DiskName { get; private set; }
        public string FreeSpace { get; private set; }
        public string TotalSize { get; private set; }

        private string FormatBytes(long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024;
            }
            
            return String.Format("{0:0.##} {1}", dblSByte, suffix[i]);
        }
    }
}
