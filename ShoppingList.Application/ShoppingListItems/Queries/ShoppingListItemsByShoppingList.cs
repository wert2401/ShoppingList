using ErrorOr;
using MediatR;
using ShoppingList.Application.ShoppingLists;
using ShoppingList.Domain.ShopListItems;
using ShoppingList.Domain.ShoppingListItems;
using ShoppingList.Domain.ShoppingLists;

namespace ShoppingList.Application.ShoppingListItems.Queries
{
    public record ShoppingListItemsByShoppingListQuery(Guid ShoppingListGuid) : IRequest<ErrorOr<IEnumerable<ShoppingListItem>>>;

    internal class ShoppingListItemsByShoppingListHandler : IRequestHandler<ShoppingListItemsByShoppingListQuery, ErrorOr<IEnumerable<ShoppingListItem>>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public ShoppingListItemsByShoppingListHandler(
            IShoppingListRepository shoppingListRepository,
            IShoppingListItemRepository shoppingListItemRepository)
        {
            _shoppingListRepository = shoppingListRepository;
            _shoppingListItemRepository = shoppingListItemRepository;
        }

        public async Task<ErrorOr<IEnumerable<ShoppingListItem>>> Handle(ShoppingListItemsByShoppingListQuery request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository.GetByIdAsync(request.ShoppingListGuid);

            if (shoppingList is null)
            {
                return ShoppingListErrors.NotFound;
            }

            return _shoppingListItemRepository.GetByShoppingListGuid(request.ShoppingListGuid).ToErrorOr();
        }
    }
}
