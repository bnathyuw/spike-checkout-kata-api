using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.AddItemToBasket;
using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Data
{
	public class ItemStore : IStoreItems
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();

		public IEnumerable<char> GetMatching(RetrieveBasketRequest request)
		{
			return Items.Where(i => i.Matches(request)).Select(i => i.ToItem());
		}

		public void StoreItem(ItemRequest itemRequest)
		{
			Items.Add(itemRequest.ToItemInStore());
		}
	}
}