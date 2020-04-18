using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using WebCLI.Domain.Interfaces.Services;
using WebCLI.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace WebCLI.Application.Services
{
    public class ServiceInformation : IServiceInformation
    {
        private readonly RestClient restClient;
        private readonly IConfiguration _configuration;
        public ServiceInformation(IConfiguration configuration)
        {
            _configuration = configuration;
            restClient = new RestClient(_configuration["CoreApiSettings"]);
        }
        public AntivirusInfo GetAntivirusInfo()
        {
            var antivirusInfo = new AntivirusInfo();
            var objectCollection = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct").Get();

            antivirusInfo.HasAntivirusInstalled = (objectCollection.Count > 0);

            foreach (ManagementObject virusChecker in objectCollection)
            {
                antivirusInfo.ApplicationName += virusChecker["displayName"].ToString() + " ";
            }

            return antivirusInfo;
        }

        public ICollection<HardDriveInfo> GetHardDriveInfos()
        {
            var diskCollection = new List<HardDriveInfo>();
            
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                diskCollection.Add(new HardDriveInfo(drive.Name, drive.TotalFreeSpace, drive.TotalSize));
            }

            return diskCollection;
        }

        public string GetLocalIpAddress()
        {
            string hostName = Dns.GetHostName();
            var addresses = Dns.GetHostAddresses(hostName);

            if (addresses.Any(x => x.AddressFamily == AddressFamily.InterNetwork))
                return addresses.Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
            else
                return "No network adapters with an IPv4 address in the system!";
        }

        public string GetMachineName() => Environment.MachineName;

        public string GetOSVersion() => Environment.OSVersion.VersionString;

        public string GetRuntimeInstalledVersion() => $"{AppContext.TargetFrameworkName.Split(",")[0]} {Environment.Version}";

        public void Subscribe()
        {
            var infoRegistration = new ServiceInfoRegistration();

            infoRegistration.AntivirusInfo = GetAntivirusInfo();
            infoRegistration.HardDriveInfos = GetHardDriveInfos();
            infoRegistration.LocalAddress = GetLocalIpAddress();
            infoRegistration.MachineName = GetMachineName();
            infoRegistration.RuntimeVersion = GetRuntimeInstalledVersion();
            infoRegistration.WindowsVersion = GetOSVersion();

            var request = new RestRequest("services/v1/subscribe", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(infoRegistration));
            var resp = restClient.Execute(request);
        }

        public void Unsubscribe()
        {
            var infoRegistration = new ServiceInfoRegistration();

            infoRegistration.AntivirusInfo = GetAntivirusInfo();
            infoRegistration.HardDriveInfos = GetHardDriveInfos();
            infoRegistration.LocalAddress = GetLocalIpAddress();
            infoRegistration.MachineName = GetMachineName();
            infoRegistration.RuntimeVersion = GetRuntimeInstalledVersion();
            infoRegistration.WindowsVersion = GetOSVersion();

            var request = new RestRequest("services/v1/unsubscribe", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(infoRegistration));
            var resp = restClient.Execute(request);
        }
    }
}
