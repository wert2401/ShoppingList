using ErrorOr;

namespace ShoppingList.Application.ShoppingListItems
{
    public static class ShoppingListItemsErrors
    {
        public static Error NotFound => Error.NotFound(description: "Shopping list item not found.");
    }
}
