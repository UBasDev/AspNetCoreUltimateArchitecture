using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Entities.Common;
using UserService.Persistence.Context;

namespace UserService.Persistence.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
        //Bütün entityleri `BaseEntity`den inherit ettiğimiz için böyle kullandık. Eğer bir base entity yoksa basitçe `: class` şeklinde de kullanabiliriz
    {
        protected readonly ApplicationDbContext Context;
        private readonly DbSet<TEntity> _dbSet;

        protected GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual TEntity GetSingleById(int id)
        {
            return _dbSet.Find(id) ?? throw new InvalidOperationException();
        }

        public virtual async Task<TEntity> GetSingleByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id) ?? throw new InvalidOperationException();
        }

        public virtual TEntity? GetSingleByIdAsNoTracking(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return null;
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<TEntity?> GetSingleByIdAsNoTrackingAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.Where(predicate);
            return query;
        }

        public virtual IQueryable<TEntity> FindByConditionAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.AsNoTracking().Where(predicate);
            return query;
        }

        public virtual void InsertSingle(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task InsertSingleAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public virtual async Task DeleteSingleByIdAsync(object id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null) DeleteSingle(entityToDelete);
        }

        public virtual void DeleteSingle(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
        {
            var toDelete = entitiesToDelete.ToList();
            foreach (var entity in toDelete.Where(entity => Context.Entry(entity).State == EntityState.Detached))
            {
                _dbSet.Attach(entity);
            }

            _dbSet.RemoveRange(toDelete);
        }

        public virtual void UpdateSingle(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (var entity in entitiesToUpdate)
            {
                _dbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
