using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.Data.Contexts;

namespace StoreOperation.WebApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected StoreOperationDbContext _storeOperationDb;

        public Repository(StoreOperationDbContext storeOperationDb)
        {
            _storeOperationDb = storeOperationDb;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.GetAllAsync(null, null, null, null, null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.GetAllAsync(predicate, null, null, null, null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            return await this.GetAllAsync(null, include, null, null, null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            return await Task.Run(() => GetQueryable(predicate, include));
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null,
            int? take = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await Task.Run((() => query));
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, string orderBy = null,
            string orderDirection = "asc",
            int? skip = null, int? take = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy, orderDirection);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await Task.Run(() => query);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await GetQueryable(predicate, include).SingleOrDefaultAsync();
        }

        public async Task<int> Count()
        {
            return await _storeOperationDb.Set<T>().CountAsync();
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return await _storeOperationDb.Set<T>().Where(predicate).CountAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _storeOperationDb.Set<T>().AnyAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _storeOperationDb.Set<T>().AddAsync(entity);
            await _storeOperationDb.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T toUpdate)
        {
            //todo çok sağlıklı bir yapı olmadı 'entityentry to entity' araştırılıp uygulanmalı

            _storeOperationDb.Set<T>().Update(toUpdate);
            await _storeOperationDb.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _storeOperationDb.Set<T>().Remove(entity);
            return await _storeOperationDb.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var tbl = _storeOperationDb.Set<T>();
            tbl.RemoveRange(tbl.Where(predicate).ToArray());
            return await _storeOperationDb.SaveChangesAsync();
        }

        public async Task<int> SaveASync()
        {
            return await _storeOperationDb.SaveChangesAsync();
        }

        private IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _storeOperationDb.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public async ValueTask DisposeAsync()
        {
            await _storeOperationDb.DisposeAsync();
        }
    }
}