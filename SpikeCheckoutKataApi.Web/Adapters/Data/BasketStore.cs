using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using Handler = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Handler;
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
			var id = GetNextId();
			var basket = request.ToBasketInStoreWithId(id);
			Baskets.Add(basket);
			return new CreatedBasket(id);
		}

		private static int GetNextId()
		{
			return ++_currentId;
		}
	}
}