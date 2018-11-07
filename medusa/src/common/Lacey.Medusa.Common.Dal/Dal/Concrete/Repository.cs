using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Common.Dal.Dal.Concrete
{
    public sealed class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        private readonly IDbContext context;
        
        private readonly DbSet<TEntity> dbset;

        public Repository(IDbContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>(); 
        }

        public void Attach(TEntity entity)
        {
            this.dbset.Attach(entity);
        }

        public void Add(TEntity entity)
        {
            this.dbset.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbset.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            var entry = this.context.Entry(entity);
            this.dbset.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludedProperties)
        {
            var entry = this.context.Entry(entity);
            this.dbset.Attach(entity);
            entry.State = EntityState.Modified;

            foreach (var property in excludedProperties)
            {
                entry.Property(property).IsModified = false;
            }
        }

        public TEntity GetById<TId>(TId id)
        {
            return this.dbset.Find(id);
        }

        public void DeleteById<TId>(TId id)
        {
            var entity = this.dbset.Find(id);
            this.dbset.Remove(entity);
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            var delList = this.dbset.Where(predicate);

            foreach (var entity in delList)
            {
                var entry = this.context.Entry(entity);
                entry.State = EntityState.Deleted;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbset;
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.dbset;

            return includeProperties.Aggregate(query, (current, property) => current.Include(property));
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbset.Where(predicate);
        }

        public IQueryable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.dbset.Where(predicate);

            return includeProperties.Aggregate(query, (current, property) => current.Include(property));
        }

        public void Clear()
        {
            var tableName = this.context.GetTableName<TEntity>();
            var sqlCommand = $"DELETE FROM [{tableName}]; DBCC CHECKIDENT ([{tableName}], RESEED, 1);";
            this.context.ExecuteCommand(sqlCommand);
        }

        public async Task AddAsync(TEntity entity)
        {
            await this.dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.dbset.AddRangeAsync(entities);
        }

        public async Task<TEntity> GetByIdAsync<TId>(TId id)
        {
            return await this.dbset.FindAsync(id);
        }

        public async Task BulkAddAsync<T>(IEnumerable<T> entities) where T : class
        {
            await this.context.BulkAddAsync(entities);
        }
    }
}