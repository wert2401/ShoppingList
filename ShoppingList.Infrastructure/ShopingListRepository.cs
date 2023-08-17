using Blazored.LocalStorage;
using ShoppingList.Application.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Infrastructure
{
    internal class ShopingListRepository : IRepository<Domain.ShopList, string>
    {
        private readonly ILocalStorageService _localStorage;

        public ShopingListRepository(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<Domain.ShopList> GetAsync(string id)
        {
            return await _localStorage.GetItemAsync<Domain.ShopList>(id);
        }

        public async Task CreateAsync(Domain.ShopList entity)
        {
            if (await _localStorage.ContainKeyAsync(entity.Name))
                throw new ValidationException($"List with name {entity.Name} already exist.");

            await _localStorage.SetItemAsync(entity.Name, entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _localStorage.RemoveItemAsync(id);
        }

        public async Task UpdateAsync(Domain.ShopList entity)
        {
            if (!await _localStorage.ContainKeyAsync(entity.Name))
                throw new ValidationException($"List with name {entity.Name} does not exist.");

            await _localStorage.SetItemAsync(entity.Name, entity);
        }
    }
}
