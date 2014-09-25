using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Http.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Http.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Data
{
	public class BasketStore
	{
		private static int _currentId;
		private static readonly List<BasketInStore> Members = new List<BasketInStore>();

		public Basket GetBasket(int id)
		{
			return Members.Single(b => b.WithId(id)).ToBasketResponse();
		}

		public int CreateBasket()
		{
			var id = GetNextId();
			var basket = new BasketInStore(id);
			Members.Add(basket);
			return id;
		}

		public void AddItemToBasket(AddItemToBasketRequest addItemToBasketRequest)
		{
			var basket = Members.Single(b => b.WithId(addItemToBasketRequest.Id));
			basket.AddItem(addItemToBasketRequest.Item);
		}

		private static int GetNextId()
		{
			return ++_currentId;
		}
	}
}