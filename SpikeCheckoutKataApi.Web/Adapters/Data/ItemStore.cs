using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;
using AddItemToBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Request;
using DeleteItemFromBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket.Request;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class ItemStore : IStoreItems, IDeleteItemsFromBaskets
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();
		private int _currentId;

		public IEnumerable<char> GetMatching(RetrieveBasketRequest request)
		{
			return Items.Where(i => i.Matches(request)).Select(i => i.ToItem());
		}

		public CreatedItem StoreItem(AddItemToBasketRequest request)
		{
			var itemId = GetNextId();
			var itemInStore = request.Create((code, basketId) => new ItemInStore(code, basketId, itemId));
			Items.Add(itemInStore);
			return itemInStore.ToCreatedItem();
		}

		private int GetNextId()
		{
			return ++_currentId;
		}

		public void DeleteItem(DeleteItemFromBasketRequest request)
		{
			var item = Items.Single(i => i.Matches(request));
			Items.Remove(item);
		}
	}
}