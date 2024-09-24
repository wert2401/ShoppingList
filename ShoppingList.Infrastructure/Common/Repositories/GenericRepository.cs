using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.Common.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly IDbContextFactory<AppDbContext> _appDbContextFactory;

        protected AppDbContext AppDbContext { get; set; } = null!;

        public GenericRepository(IDbContextFactory<AppDbContext> appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }

        protected async Task InitAsync()
        {
            AppDbContext = await _appDbContextFactory.CreateDbContextAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await InitAsync();

            await AppDbContext.AddAsync(entity);

            await AppDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            await InitAsync();

            return AppDbContext.Set<TEntity>()
                .AsNoTracking();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            await InitAsync();

            var entity = await AppDbContext.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            await InitAsync();

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
            await InitAsync();

            AppDbContext.Set<TEntity>().Update(entity);

            await AppDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
