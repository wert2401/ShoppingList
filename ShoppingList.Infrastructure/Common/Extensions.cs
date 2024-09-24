using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Infrastructure.Persistence;

namespace ShoppingList.Infrastructure.Common
{
    public static class Extensions
    {
        public static async Task MigrateAsync(this IServiceScope scope)
        {
            await using var dbContext = await scope.ServiceProvider
               .GetRequiredService<IDbContextFactory<AppDbContext>>()
               .CreateDbContextAsync();

            await dbContext.Database.MigrateAsync();

            await dbContext.SaveChangesAsync();
        }
    }
}
