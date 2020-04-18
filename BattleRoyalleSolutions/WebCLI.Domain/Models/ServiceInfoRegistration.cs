using System;
using System.Collections.Generic;
using System.Text;

namespace WebCLI.Domain.Models
{
    public class ServiceInfoRegistration
    {
        public string MachineName { get; set; }
        public string LocalAddress { get; set; }
        public AntivirusInfo AntivirusInfo { get; set; }
        public string WindowsVersion { get; set; }
        public string RuntimeVersion { get; set; }
        public ICollection<HardDriveInfo> HardDriveInfos { get; set; }
    }
}
