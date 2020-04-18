using CoreAPI.Domain.Interfaces.Repositories;
using CoreAPI.Infra.Data.Contexts;
using System;
using System.IO;
using System.Text;

namespace CoreAPI.Infra.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly SQLiteDbContext _context;

        public LogRepository(SQLiteDbContext context)
        {
            _context = context;
        }

        public async void LogMessageAsync(string category, string message, DateTime dateTime)
        {
            string logFilePath = Path.Combine(AppContext.BaseDirectory, "logfile.txt");

            using (var stream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Write, 4096, useAsync: true))
            {
                var bytes = Encoding.UTF8.GetBytes($"{category} - {message} at {dateTime}" + Environment.NewLine);
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
