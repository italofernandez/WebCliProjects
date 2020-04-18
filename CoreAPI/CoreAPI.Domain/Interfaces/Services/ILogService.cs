using System;
namespace CoreAPI.Domain.Interfaces.Services
{
    public interface ILogService
    {
        void LogMessage(string category, string message, DateTime dateTime);
    }
}
