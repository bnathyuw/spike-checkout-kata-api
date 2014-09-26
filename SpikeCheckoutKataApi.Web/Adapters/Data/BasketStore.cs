using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class BasketStore : IGetBaskets, ICreateBaskets
	{
		private static int _currentId;
		private static readonly List<BasketInStore> Baskets = new List<BasketInStore>();
		private readonly ItemStore _itemStore = new ItemStore();

		public BasketResponse GetBasket(Request request)
		{
			var basketInStore = Baskets.Single(b => b.Matching(request));
			var basketContents = _itemStore.GetMatching(request);
			return basketInStore.ToResponseWithContents(basketContents);
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