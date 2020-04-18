using WebCLI.Domain.Interfaces.Services;
using System.Diagnostics;

namespace WebCLI.Application.Services
{
    public class CommandService : ICommandService
    {
        public string ExecuteCommand(string command)
        {
            // executar o command no CMD do Windows e retornar seu OUTPUT
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                FileName = "CMD.exe",
                Arguments = @$"/c {command}",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized
            };
            process.StartInfo = startInfo;
            process.Start();

            string standardOutput = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            return (string.IsNullOrEmpty(standardOutput)) ? $"Exit code: {process.ExitCode}" : standardOutput;
        }
    }
}
