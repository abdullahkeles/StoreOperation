using System;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Data.Repositories.Abstract
{
    public interface IUserRepository:IRepository<AppUser>
    {
        Task<AppUser> GetByIdAsync(Guid id);
        Task<AppUser> GetByUserNameAsync(string userName);
        Task<AppUser> GetAsync(Guid userId, string hashedPassword);
        Task<AppUser> GetAsync(string userId, string hashedPassword);
        Task<AppUser> GetByEmailAsync(string email);
        Task<AppUser> GetAsync(Guid securityKey);
        Task<bool> IsExistsAsync(Guid id);
    }
}