using ErrorOr;
using MediatR;
using ShoppingList.Application.ShoppingLists;
using ShoppingList.Domain.ShopListItems;
using ShoppingList.Domain.ShoppingListItems;
using ShoppingList.Domain.ShoppingLists;

namespace ShoppingList.Application.ShoppingListItems.Commands
{
    public record AddShoppingListItemCommand(
        Guid ShoppingListGuid, 
        string ShoppingListItemName)
        : IRequest<ErrorOr<Success>>;

    internal class AddShoppingListItemHandler : IRequestHandler<AddShoppingListItemCommand, ErrorOr<Success>>
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;
        private readonly IShoppingListRepository _shoppingListRepository;

        public AddShoppingListItemHandler(IShoppingListItemRepository shoppingListItemRepository, IShoppingListRepository shoppingListRepository)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository.GetByIdAsync(request.ShoppingListGuid);

            if (shoppingList is null)
            {
                return ShoppingListErrors.NotFound;
            }

            var shoppingListItem = new ShoppingListItem()
            {
                Name = request.ShoppingListItemName,
                IsBought = false,
                StatusChangedCount = 0,
                ShoppingListId = request.ShoppingListGuid
            };

            await _shoppingListItemRepository.AddAsync(shoppingListItem);

            return Result.Success;
        }
    }
}
