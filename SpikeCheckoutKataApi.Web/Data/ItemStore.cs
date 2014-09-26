using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Http.AddItemToBasket;

namespace SpikeCheckoutKataApi.Web.Data
{
	public class ItemStore
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();

		public IEnumerable<char> GetForBasket(int basketId)
		{
			return Items.Where(i => i.IsInBasket(basketId)).Select(i => i.ToItem());
		}

		public void StoreItem(ItemRequest itemRequest)
		{
			Items.Add(itemRequest.ToItemInStore());
		}
	}
}