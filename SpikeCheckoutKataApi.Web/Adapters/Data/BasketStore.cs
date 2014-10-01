using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class BasketStore : IGetBaskets, ICreateBaskets
	{
		private static int _currentId;
		private static readonly List<BasketInStore> Baskets = new List<BasketInStore>();
		private readonly ItemStore _itemStore = new ItemStore();

		public BasketResponse GetBasket(RetrieveBasketRequest request)
		{
			var basketInStore = Baskets.Single(b => b.Matching(request));
			var basketContents = _itemStore.GetMatching(request);
			return basketInStore.ToResponseWithContents(basketContents);
		}

		public CreatedBasket CreateBasket(CreateBasketRequest request)
		{
			var basketId = GetNextId();
			var basket = request.Create(shopper => new BasketInStore(basketId, shopper));
			Baskets.Add(basket);
			return basket.ToCreatedBasket();
		}

		private static int GetNextId()
		{
			return ++_currentId;
		}
	}
}