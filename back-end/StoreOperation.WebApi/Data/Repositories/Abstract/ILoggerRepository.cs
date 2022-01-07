using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Data.Repositories.Abstract
{
    public interface ILoggerRepository : IRepository<AppLog>
    {
        Task<List<AppLog>> GetListAsync(int count);
        Task WriteInfoAsync(string message);
        Task WriteErrorAsync(string message);
        Task WriteErrorAsync(Exception ex);
        Task WriteLogAsync(string message, string stackTrace, string level);
    }
}