using ErrorOr;

namespace ShoppingList.Application.ShoppingLists
{
    internal static class ShoppingListErrors
    {
        public static Error NotFound => Error.NotFound(description: "Shopping list not found.");
    }
}
