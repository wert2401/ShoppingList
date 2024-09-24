using ErrorOr;
using MediatR;
using ShoppingList.Domain.ShopListItems;

namespace ShoppingList.Application.ShoppingListItems.Commands
{
    public record SetShoppingListItemNameCommand(Guid ShoppingListItemGuid, string Name) : IRequest<ErrorOr<Success>>;

    internal class SetShoppingListItemNameHandler : IRequestHandler<SetShoppingListItemNameCommand, ErrorOr<Success>>
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public SetShoppingListItemNameHandler(IShoppingListItemRepository shoppingListItemRepository)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
        }

        public async Task<ErrorOr<Success>> Handle(SetShoppingListItemNameCommand request, CancellationToken cancellationToken)
        {
            var item = await _shoppingListItemRepository.GetByIdAsync(request.ShoppingListItemGuid);

            if (item == null)
            {
                return ShoppingListItemsErrors.NotFound;
            }

            item.Name = request.Name;

            await _shoppingListItemRepository.UpdateAsync(item);

            return Result.Success;
        }
    }
}
