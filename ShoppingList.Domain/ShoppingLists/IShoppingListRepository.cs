using ShoppingList.Domain.Common.Repositories;

namespace ShoppingList.Domain.ShoppingLists
{
    public interface IShoppingListRepository : IGenericRepository<ShoppingList, Guid>
    {
    }
}
