using CoreAPI.Domain.Entities;

namespace CoreAPI.Domain.ValueObjects
{
    public class HardDriveInfo : Entity
    {
        public string DiskName { get; set; }
        public string FreeSpace { get; set; }
        public string TotalSize { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}