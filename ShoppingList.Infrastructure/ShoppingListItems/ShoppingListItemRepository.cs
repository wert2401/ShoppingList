using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.ShopListItems;
using ShoppingList.Domain.ShoppingListItems;
using ShoppingList.Infrastructure.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.ShoppingListItems
{
    internal class ShoppingListItemRepository : GenericWebAssemblyRepository<ShoppingListItem, Guid>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository(IDbContextFactory<AppDbContext> appDbContextFactory) : base(appDbContextFactory)
        {
        }

        public async Task<IEnumerable<ShoppingListItem>> GetByShoppingListGuidAsync(Guid shoppingListGuid)
        {
            using var appDbContext = await GetAppDbContextAsync();

            return await appDbContext.ShoppingListItems.Where(x => x.ShoppingListId == shoppingListGuid)
                .ToListAsync();
        }
    }
}
