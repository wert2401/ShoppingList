using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.ShoppingListItems;

namespace ShoppingList.Infrastructure.Persistence
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            
        public DbSet<Domain.ShoppingLists.ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
