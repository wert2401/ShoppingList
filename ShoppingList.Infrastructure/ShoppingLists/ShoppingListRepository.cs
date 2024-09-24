using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.ShoppingLists;
using ShoppingList.Infrastructure.Common.Repositories;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.ShoppingLists
{
    internal class ShoppingListRepository : GenericRepository<Domain.ShoppingLists.ShoppingList, Guid>, IShoppingListRepository
    {
        public ShoppingListRepository(IDbContextFactory<AppDbContext> appDbContextFactory) : base(appDbContextFactory)
        {
        }
    }
}
