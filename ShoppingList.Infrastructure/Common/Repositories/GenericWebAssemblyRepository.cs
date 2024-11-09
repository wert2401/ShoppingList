using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.Common.Repositories
{
    internal class GenericWebAssemblyRepository<TEntity, TKey>(IDbContextFactory<AppDbContext> appDbContextFactory)
        : IGenericRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        protected async Task<AppDbContext> GetAppDbContextAsync()
        {
            return await appDbContextFactory.CreateDbContextAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await using var appDbContext = await GetAppDbContextAsync();

            await appDbContext.AddAsync(entity);

            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            await using var appDbContext = await GetAppDbContextAsync();

            return await appDbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            await using var appDbContext = await GetAppDbContextAsync();

            var entity = await appDbContext.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            await using var appDbContext = await GetAppDbContextAsync();

            var entity = await appDbContext.Set<TEntity>().FindAsync(id);

            if (entity is null)
            {
                return;
            }

            appDbContext.Set<TEntity>().Remove(entity);

            await appDbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await using var appDbContext = await GetAppDbContextAsync();

            appDbContext.Set<TEntity>().Update(entity);

            await appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}