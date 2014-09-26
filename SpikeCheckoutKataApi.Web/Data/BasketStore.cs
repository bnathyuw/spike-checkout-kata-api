using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Http.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Data
{
	public class BasketStore
	{
		private static int _currentId;
		private static readonly List<BasketInStore> Baskets = new List<BasketInStore>();
		private readonly ItemStore _itemStore = new ItemStore();

		public Basket GetBasket(int id)
		{
			var basketInStore = Baskets.Single(b => b.WithId(id));
			var basketContents = _itemStore.GetForBasket(id);
			return basketInStore.ToBasketWithContents(basketContents);
		}

		public int CreateBasket()
		{
			var id = GetNextId();
			var basket = new BasketInStore(id);
			Baskets.Add(basket);
			return id;
		}

		private static int GetNextId()
		{
			return ++_currentId;
		}
	}
}