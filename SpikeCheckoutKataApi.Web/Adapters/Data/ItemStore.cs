using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using Request = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class ItemStore : IStoreItems
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();

		public IEnumerable<char> GetMatching(Request request)
		{
			return Items.Where(i => i.Matches(request)).Select(i => i.ToItem());
		}

		public void StoreItem(Behaviour.AddItemToBasket.Request request)
		{
			Items.Add(request.ToItemInStore());
		}
	}
}