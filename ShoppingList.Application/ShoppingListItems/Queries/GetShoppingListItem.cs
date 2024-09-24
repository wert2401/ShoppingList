using ErrorOr;
using MediatR;
using ShoppingList.Domain.ShopListItems;
using ShoppingList.Domain.ShoppingListItems;

namespace ShoppingList.Application.ShoppingListItems.Queries
{
    public record GetShoppingListItemQuery(Guid ShoppingListItemGuid) : IRequest<ErrorOr<ShoppingListItem>>;

    internal class GetShoppingListItemHandler : IRequestHandler<GetShoppingListItemQuery, ErrorOr<ShoppingListItem>>
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public GetShoppingListItemHandler(IShoppingListItemRepository shoppingListItemRepository)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
        }

        public async Task<ErrorOr<ShoppingListItem>> Handle(GetShoppingListItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _shoppingListItemRepository.GetByIdAsync(request.ShoppingListItemGuid);

            if (item == null)
            {
                return ShoppingListItemsErrors.NotFound;
            }

            return item;
        }
    }
}
