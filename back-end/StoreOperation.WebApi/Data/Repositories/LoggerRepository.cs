using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class LoggerRepository : Repository<AppLog>, ILoggerRepository
    {
        public LoggerRepository(StoreOperationDbContext context) : base(context)
        {
        }

        public Task<List<AppLog>> GetListAsync(int count)
        {
            return _storeOperationDb.AppLogs.OrderByDescending(log => log.InsertDate).Take(count).ToListAsync();
        }

        public async Task WriteInfoAsync(string message)
        {
            await WriteLogAsync(message, null, "INFO");
        }

        public async Task WriteErrorAsync(string message)
        {
            await WriteLogAsync(message, null, "ERROR");
        }

        public async Task WriteErrorAsync(Exception ex)
        {
            var message = ex.Message;
            var stackTrace = ex.StackTrace;

            if (ex.InnerException != null)
            {
                message += Environment.NewLine + "InnerException: " + ex.InnerException.Message;
                stackTrace += Environment.NewLine + "InnerException: " + ex.InnerException.StackTrace;
            }
            await WriteLogAsync(message, stackTrace, "ERROR");
        }

        public async Task WriteLogAsync(string message, string stackTrace, string level)
        {
            var log = new AppLog()
            {
                //Id = Guid.NewGuid(),
                Level = level,
                Message = message,
                StackTrace = stackTrace,
                InsertDate = DateTime.Now
            };

            await _storeOperationDb.AppLogs.AddAsync(log);
            await _storeOperationDb.SaveChangesAsync();
        }
    }
}
