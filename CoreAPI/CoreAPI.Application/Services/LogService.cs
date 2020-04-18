using CoreAPI.Domain.Interfaces.Repositories;
using CoreAPI.Domain.Interfaces.Services;
using System;

namespace CoreAPI.Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void LogMessage(string category, string message, DateTime dateTime)
        {
            _logRepository.LogMessageAsync(category, message, dateTime);
        }
    }
}
