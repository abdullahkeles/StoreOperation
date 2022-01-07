using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreOperation.WebApi.Common.DataAccess;
using StoreOperation.WebApi.Data.Entities;

namespace StoreOperation.WebApi.Data.Repositories.Abstract
{
    public interface ICheckListQuestionRepository:IRepository<CheckListQuestion>
    {
        /// <summary>
        /// entity silinmez state flase çekilerek pasif yapılır.
        /// </summary>
        /// <param name="id">pasif yapılacak CheckListQuestion entity key</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(Guid id);
        /// <summary>
        /// entity silinmez state flase çekilerek pasif yapılır.
        /// </summary>
        /// <param name="ids">pasif yapılacak CheckListQuestion entity keys</param>
        /// <returns></returns>
        Task<bool> RemoveAllAsync(IEnumerable<Guid> ids);
    }
}