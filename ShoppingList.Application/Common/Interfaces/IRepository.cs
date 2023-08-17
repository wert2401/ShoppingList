namespace ShoppingList.Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        public Task<TEntity> GetAsync(TKey id);
        public Task DeleteAsync(TKey id);
        public Task UpdateAsync(TEntity entity);
        public Task CreateAsync(TEntity entity);
    }
}
