using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;
using Request = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class ItemStore : IStoreItems, IDeleteItemsFromBaskets
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();
		private int _currentId;

		public IEnumerable<char> GetMatching(Request request)
		{
			return Items.Where(i => i.Matches(request)).Select(i => i.ToItem());
		}

		public int StoreItem(Behaviour.AddItemToBasket.Request request)
		{
			var id = GetNextId();
			var itemInStore = request.ToItemInStoreWithId(id);
			Items.Add(itemInStore);
			return id;
		}

		private int GetNextId()
		{
			return ++_currentId;
		}

		public void DeleteItem(Behaviour.DeleteItemFromBasket.Request request)
		{
			ItemInStore item = Items.Single(i => i.Matches(request));
			Items.Remove(item);
		}
	}
}