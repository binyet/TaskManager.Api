using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DBContext;
using TaskManager.Entities;

namespace TaskManager.Repository
{
    public class KeyRepository<TEntity> : Repository<TEntity>, IKeyRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public KeyRepository(TaskManagerContext context) : base(context)
        {
        }
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity), "entity为空");
            this.Store.Add(entity);
            await this.Store.SaveChangesAsync();
            return entity;
        }
        public async Task InsertAsync(IEnumerable<TEntity> entities)
        {
            if (!entities.Any()) return;
            this.Store.AddRange(entities);
            await this.Store.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity), "entity为空");
            this.Store.Update(entity);
            await this.Store.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (!entities.Any()) return;
            this.Store.UpdateRange(entities);
            await this.Store.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity), "entity为空");
            this.Store.Remove(entity);
            await this.Store.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            if (!entities.Any()) return;
            this.Store.RemoveRange(entities);
            await this.Store.SaveChangesAsync();
        }

    }
}
