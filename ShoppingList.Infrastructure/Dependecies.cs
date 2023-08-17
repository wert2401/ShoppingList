using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Application.Common.Interfaces;

namespace ShoppingList.Infrastructure
{
    public static class Dependecies
    {
        public static void RegisterInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository<Domain.ShopList, string>, ShopingListRepository>();
        }
    }
}
