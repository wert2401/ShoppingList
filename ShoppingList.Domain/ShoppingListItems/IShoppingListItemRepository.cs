using ShoppingList.Domain.Common.Repositories;
using ShoppingList.Domain.ShoppingListItems;

namespace ShoppingList.Domain.ShopListItems
{
    public interface IShoppingListItemRepository : IGenericRepository<ShoppingListItem, Guid>
    {
        IEnumerable<ShoppingListItem> GetByShoppingListGuid(Guid shoppingListGuid);
    }
}
