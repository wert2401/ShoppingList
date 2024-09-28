using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.ShopListItems;
using ShoppingList.Domain.ShoppingListItems;
using ShoppingList.Infrastructure.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.ShoppingListItems
{
    internal class ShoppingListItemRepository : GenericRepository<ShoppingListItem, Guid>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository(IDbContextFactory<AppDbContext> appDbContextFactory) : base(appDbContextFactory)
        {
        }

        public IEnumerable<ShoppingListItem> GetByShoppingListGuid(Guid shoppingListGuid)
        {
            return AppDbContext.ShoppingListItems.Where(x => x.ShoppingListId == shoppingListGuid);
        }
    }
}
