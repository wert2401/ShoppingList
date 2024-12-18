﻿using MediatR;
using ShoppingList.Domain.ShoppingLists;

namespace ShoppingList.Application.ShoppingLists.Queries
{
    public record AllShoppingListsQuery() : IRequest<IEnumerable<Domain.ShoppingLists.ShoppingList>>;

    internal class AllShoppingListsHandler : IRequestHandler<AllShoppingListsQuery, IEnumerable<Domain.ShoppingLists.ShoppingList>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public AllShoppingListsHandler(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<IEnumerable<Domain.ShoppingLists.ShoppingList>> Handle(AllShoppingListsQuery request, CancellationToken cancellationToken)
        {
            return await _shoppingListRepository.GetAllAsync();
        }
    }
}
