using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;
using AddItemToBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Request;
using DeleteItemFromBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket.Request;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class ItemStore : IStoreItems, IDeleteItemsFromBaskets
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();
		private int _currentId;

		public IEnumerable<char> GetMatching(BasketInStore basket)
		{
			return Items.Where(i => i.Matches((itemId, basketId) => basket.Matches(basketId)))
			            .Select(i => i.Create(CreateItemInBasket));
		}

		private static char CreateItemInBasket(int id, int basketId, char code)
		{
			return code;
		}

		public ICompleteItemTemplates StoreItem(AddItemToBasketRequest request)
		{
			var itemInStore = request.Create(CreateItemInStore);
			Items.Add(itemInStore);
			return itemInStore.Create(CreateStoredItem);
		}

		private int GetNextId()
		{
			return ++_currentId;
		}

		private ItemInStore CreateItemInStore(char code, int basketId)
		{
			var itemId = GetNextId();
			return new ItemInStore(code, basketId, itemId);
		}

		private static CreatedItem CreateStoredItem(int id, int basket, char code)
		{
			return new CreatedItem(id, basket);
		}

		public void DeleteItem(DeleteItemFromBasketRequest request)
		{
			var item = Items.Single(i => i.Matches((itemId, basketId) => request.Matches(basketId, itemId)));
			Items.Remove(item);
		}
	}
}