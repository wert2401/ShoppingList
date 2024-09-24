using ShoppingList.Domain.ShoppingListItems;

namespace ShoppingList.Domain.ShoppingLists
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();

        public void AddNewItem(ShoppingListItem item)
        {
            Items.Add(item);
        }
    }
}
