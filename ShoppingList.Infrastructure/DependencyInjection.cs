using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Domain.ShopListItems;
using ShoppingList.Domain.ShoppingLists;
using ShoppingList.Infrastructure.Persistence;
using ShoppingList.Infrastructure.ShoppingListItems;
using ShoppingList.Infrastructure.ShoppingLists;

namespace ShoppingList.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddBesqlDbContextFactory<AppDbContext>(o => o.UseSqlite(configuration.GetConnectionString("shoppingListDb")));

            serviceCollection.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IShoppingListRepository, ShoppingListRepository>();
            serviceCollection.AddScoped<IShoppingListItemRepository, ShoppingListItemRepository>();
        }
    }
}
