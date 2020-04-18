using System;
using System.Threading.Tasks;

namespace CoreAPI.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        void LogMessageAsync(string category, string message, DateTime dateTime);
    }
}
