using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace NetCoreTodoApi.Repositories
{
    /// <summary>
    /// BaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, new()
    {
        protected DbContext DbContext;
        protected DbSet<TEntity> DbSet;

        /// <summary>
        /// BaseRepository
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;

            DbSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return DbSet.SingleOrDefault(predicate);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return DbSet.Where(predicate);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        
        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }
        }
    }
}
