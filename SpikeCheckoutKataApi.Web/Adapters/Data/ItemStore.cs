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
			var id = GetNextId();
			var itemInStore = request.ToItemInStoreWithId(id);
			Items.Add(itemInStore);
			return new CreatedItem(id, request.BasketId);
		}

		private int GetNextId()
		{
			return ++_currentId;
		}

		public void DeleteItem(DeleteItemFromBasketRequest request)
		{
			ItemInStore item = Items.Single(i => i.Matches(request));
			Items.Remove(item);
		}
	}
}