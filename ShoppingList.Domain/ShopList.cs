namespace ShoppingList.Domain
{
    public class ShopList
    {
        public string Name { get; set; } = null!;
        public ICollection<ShopListItem> Items { get; set; }
    }
}
