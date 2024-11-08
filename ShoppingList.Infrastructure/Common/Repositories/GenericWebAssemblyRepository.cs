using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.Common.Repositories
{
    internal class GenericWebAssemblyRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly IDbContextFactory<AppDbContext> _appDbContextFactory;

        protected async Task<AppDbContext> GetAppDbContextAsync()
        {
            return await _appDbContextFactory.CreateDbContextAsync();
        }

        public GenericWebAssemblyRepository(IDbContextFactory<AppDbContext> appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            using var appDbContext = await GetAppDbContextAsync();

            await appDbContext.AddAsync(entity);

            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var appDbContext = await GetAppDbContextAsync();

            return await appDbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            using var appDbContext = await GetAppDbContextAsync();

            var entity = await appDbContext.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            using var appDbContext = await GetAppDbContextAsync();

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
            using var appDbContext = await GetAppDbContextAsync();

            appDbContext.Set<TEntity>().Update(entity);

            await appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
