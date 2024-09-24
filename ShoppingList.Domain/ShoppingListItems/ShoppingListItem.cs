namespace ShoppingList.Domain.ShoppingListItems
{
    public class ShoppingListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsBought { get; set; }
        public int StatusChangedCount { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingLists.ShoppingList ShoppingList { get; set; } = null!;

        public void Check()
        {
            if (IsBought)
            {
                Unmark();
            }
            else
            {
                Mark();
            }
        }

        private void Mark()
        {
            IsBought = true;
            StatusChangedCount++;
        }

        private void Unmark()
        {
            IsBought = false;
            StatusChangedCount++;
        }
    }
}