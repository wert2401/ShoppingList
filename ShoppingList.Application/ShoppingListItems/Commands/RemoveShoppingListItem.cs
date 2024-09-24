using ErrorOr;
using MediatR;
using ShoppingList.Domain.ShopListItems;

namespace ShoppingList.Application.ShoppingListItems.Commands
{
    public record RemoveShoppingListItemCommand(Guid ShoppingListItemGuid) : IRequest<ErrorOr<Success>>;
    internal class RemoveShoppingListItemHandler : IRequestHandler<RemoveShoppingListItemCommand, ErrorOr<Success>>
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public RemoveShoppingListItemHandler(IShoppingListItemRepository shoppingListItemRepository)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
        }

        public async Task<ErrorOr<Success>> Handle(RemoveShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            await _shoppingListItemRepository.RemoveAsync(request.ShoppingListItemGuid);

            return Result.Success;
        }
    }
}
