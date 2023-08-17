namespace ShoppingList.Domain
{
    public class ShopListItem
    {
        public string Name { get; set; } = null!;
        public bool IsBought { get; set; }
        public int StatusChangedCount { get; set; }
    }
}