using ShoppingList.Domain.Common.Repositories;
using ShoppingList.Domain.ShoppingListItems;

namespace ShoppingList.Domain.ShopListItems
{
    public interface IShoppingListItemRepository : IGenericRepository<ShoppingListItem, Guid>
    {
        Task<IEnumerable<ShoppingListItem>> GetByShoppingListGuid(Guid shoppingListGuid);
    }
}
