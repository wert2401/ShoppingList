using ErrorOr;
using MediatR;
using ShoppingList.Domain.ShoppingLists;

namespace ShoppingList.Application.ShoppingLists.Queries
{
    public record GetShoppingListQuery(Guid Guid) : IRequest<ErrorOr<Domain.ShoppingLists.ShoppingList>>;

    internal class GetShoppingListHandler : IRequestHandler<GetShoppingListQuery, ErrorOr<Domain.ShoppingLists.ShoppingList>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public GetShoppingListHandler(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<ErrorOr<Domain.ShoppingLists.ShoppingList>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository.GetByIdAsync(request.Guid);

            if (shoppingList is null)
            {
                return ShoppingListErrors.NotFound;
            }

            return shoppingList;
        }
    }
}
