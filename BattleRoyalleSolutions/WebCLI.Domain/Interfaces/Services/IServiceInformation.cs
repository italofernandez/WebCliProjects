using System.Collections.Generic;
using WebCLI.Domain.Models;

namespace WebCLI.Domain.Interfaces.Services
{
    public interface IServiceInformation
    {
        string GetLocalIpAddress();
        ICollection<HardDriveInfo> GetHardDriveInfos();
        AntivirusInfo GetAntivirusInfo();
        string GetMachineName();
        string GetOSVersion();
        string GetRuntimeInstalledVersion();
        void Subscribe();
        void Unsubscribe();
    }
}
