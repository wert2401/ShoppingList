using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.Common.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        protected AppDbContext AppDbContext { get; set; }

        public GenericRepository(IDbContextFactory<AppDbContext> appDbContextFactory)
        {
            AppDbContext = appDbContextFactory.CreateDbContext();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await AppDbContext.AddAsync(entity);

            await AppDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return AppDbContext.Set<TEntity>()
                .AsNoTracking();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            var entity = await AppDbContext.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            var entity = await AppDbContext.Set<TEntity>().FindAsync(id);

            if (entity is null)
            {
                return;
            }

            AppDbContext.Set<TEntity>().Remove(entity);

            await AppDbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            AppDbContext.Set<TEntity>().Update(entity);

            await AppDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
