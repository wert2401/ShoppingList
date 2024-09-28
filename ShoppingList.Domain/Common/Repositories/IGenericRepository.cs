namespace ShoppingList.Domain.Common.Repositories
{
    public interface IGenericRepository<TEntity, TKey> 
        where TEntity : class 
        where TKey : struct
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(TKey id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
