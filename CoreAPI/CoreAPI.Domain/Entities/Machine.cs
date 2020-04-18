using System.Collections.Generic;
using CoreAPI.Domain.ValueObjects;

namespace CoreAPI.Domain.Entities
{
    public class Machine : Entity
    {
        public string MachineName { get; set; }
        public string LocalAddress { get; set; }
        public AntivirusInfo AntivirusInfo { get; set; }
        public string WindowsVersion { get; set; }
        public string RuntimeVersion { get; set; }
        public ICollection<HardDriveInfo> HardDriveInfos { get; set; }
    }
}
