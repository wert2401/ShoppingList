using ErrorOr;
using MediatR;
using ShoppingList.Domain.ShopListItems;

namespace ShoppingList.Application.ShoppingListItems.Commands
{
    public record CheckShoppingListItemCommand(Guid ShoppingListItemGuid) : IRequest<ErrorOr<Success>>;

    internal class CheckShoppingListItemHandler : IRequestHandler<CheckShoppingListItemCommand, ErrorOr<Success>>
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public CheckShoppingListItemHandler(IShoppingListItemRepository shoppingListItemRepository)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
        }

        public async Task<ErrorOr<Success>> Handle(CheckShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _shoppingListItemRepository.GetByIdAsync(request.ShoppingListItemGuid);

            if (item is null)
            {
                return ShoppingListItemsErrors.NotFound;
            }

            item.Check();

            await _shoppingListItemRepository.UpdateAsync(item);

            return Result.Success;
        }
    }
}
