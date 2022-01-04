using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Repository
{
    public interface IKeyRepository<TEntity>  where TEntity : class, IEntity, new()
    {
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> InsertAsync(TEntity entity);
        Task InsertAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(IEnumerable<TEntity> entities);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Page<TKey>(Expression<Func<TEntity, TKey>> keySelector, int pageIndex, int pageSize, bool asc = true);

        IQueryable<TEntity> Page<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, int pageIndex, int pageSize, bool asc = true);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

    }
}
