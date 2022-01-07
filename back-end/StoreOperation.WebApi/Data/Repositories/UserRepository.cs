using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Data.Entities;
using StoreOperation.WebApi.Data.Repositories.Abstract;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(StoreOperationDbContext context) : base(context)
        {
        }

        public async Task<AppUser> GetByIdAsync(Guid id)
        {
            return await _storeOperationDb.AppUsers.Where(x => x.UserId == id).SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetByUserNameAsync(string userName)
        {
            return await _storeOperationDb.AppUsers.Where(x => x.UserName == userName).SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetAsync(Guid userId, string hashedPassword)
        {
            return await _storeOperationDb.AppUsers.Where(x => x.UserId == userId && x.Password == hashedPassword)
                .SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetAsync(string userId, string hashedPassword)
        {
            return await _storeOperationDb
                .AppUsers
                .Include(x => x.RelationStoreUsers)
                .Where(x => x.UserName == userId && x.Password == hashedPassword)
                .SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _storeOperationDb.AppUsers.Where(x => x.Email==email).SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetAsync(Guid securityKey)
        {
            return await _storeOperationDb.AppUsers.Where(x => x.SecurityKey==securityKey).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await Any(x => x.UserId == id);
        }
    }
}