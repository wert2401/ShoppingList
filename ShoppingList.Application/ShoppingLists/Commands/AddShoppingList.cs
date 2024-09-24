using ErrorOr;
using MediatR;
using ShoppingList.Domain.ShoppingLists;

namespace ShoppingList.Application.ShoppingLists.Commands
{
    public record AddShoppingListCommand(string Name) : IRequest<ErrorOr<Success>>;
    internal class AddShoppingListHandler : IRequestHandler<AddShoppingListCommand, ErrorOr<Success>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public AddShoppingListHandler(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddShoppingListCommand request, CancellationToken cancellationToken)
        {
            await _shoppingListRepository.AddAsync(new Domain.ShoppingLists.ShoppingList()
            {
                Name = request.Name
            });

            return Result.Success;
        }
    }
}
