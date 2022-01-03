using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DBContext;

namespace TaskManager.Repository
{
    public abstract class Repository
    {
        protected TaskManagerContext Store { get; }
        public Repository(TaskManagerContext context)
        {
            this.Store = context;
        }
    }

    public abstract class Repository<TEntity> : Repository where TEntity : class, new()
    {
        protected Repository(TaskManagerContext context) : base(context)
        {
        }

        public IDbConnection DbConnection => this.Store.Database.GetDbConnection();
        public virtual IQueryable<TEntity> Query()
        {
            return this.Store.Set<TEntity>();
        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Query().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Query().Where(predicate);
        }

        public IQueryable<TEntity> Page<TKey>(Expression<Func<TEntity, TKey>> keySelector, int pageIndex, int pageSize, bool asc = true)
        {
            var skip = (pageIndex - 1) * pageSize;
            if (asc)
                return this.Query().OrderBy(keySelector).Skip(skip).Take(pageSize);
            else
                return this.Query().OrderByDescending(keySelector).Skip(skip).Take(pageSize);
        }

        public IQueryable<TEntity> Page<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, int pageIndex, int pageSize, bool asc = true)
        {
            var skip = (pageIndex - 1) * pageSize;
            if (asc)
                return this.Where(predicate).OrderBy(keySelector).Skip(skip).Take(pageSize);
            else
                return this.Where(predicate).OrderByDescending(keySelector).Skip(skip).Take(pageSize);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await this.Query().AnyAsync();
            else
                return await this.Query().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> precicate = null)
        {
            if (precicate == null)
                return await this.Query().CountAsync();
            else
                return await this.Query().CountAsync(precicate);
        }
    }
}
