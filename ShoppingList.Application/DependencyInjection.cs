using Microsoft.Extensions.DependencyInjection;

namespace ShoppingList.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        }
    }
}
