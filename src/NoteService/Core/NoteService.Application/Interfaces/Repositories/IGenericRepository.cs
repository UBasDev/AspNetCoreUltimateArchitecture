using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAllAsNoTracking();
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync();
        TEntity GetSingleById(int id);
        Task<TEntity> GetSingleByIdAsync(object id);
        TEntity? GetSingleByIdAsNoTracking(object id);
        Task<TEntity?> GetSingleByIdAsNoTrackingAsync(object id);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindByConditionAsNoTracking(Expression<Func<TEntity, bool>> predicate);
        void InsertSingle(TEntity entity);
        Task InsertSingleAsync(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteSingleByIdAsync(object id);
        void DeleteSingle(TEntity entityToDelete);
        void DeleteRange(IEnumerable<TEntity> entitiesToDelete);
        void UpdateSingle(TEntity entityToUpdate);
        void UpdateRange(IEnumerable<TEntity> entitiesToUpdate);
    }
}
