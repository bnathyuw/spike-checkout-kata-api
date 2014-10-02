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

		public IBasketResponse GetBasket(RetrieveBasketRequest request)
		{
			var basketInStore = Baskets.Single(b => b.Matches(request.Matches));
			var basketContents = _itemStore.GetMatching(basketInStore);
			return basketInStore.Create((id, shopper) => new Basket(basketContents, shopper));
		}

		public ICompleteBasketTemplates CreateBasket(CreateBasketRequest request)
		{
			var basket = request.Create(CreateBasketInStore);
			Baskets.Add(basket);
			return basket.Create(CreateStoredBasket);
		}

		private static CreatedBasket CreateStoredBasket(int id, string shopper)
		{
			return new CreatedBasket(id);
		}

		private static BasketInStore CreateBasketInStore(string shopper)
		{
			var basketId = GetNextId();
			return new BasketInStore(basketId, shopper);
		}

		private static int GetNextId()
		{
			return ++_currentId;
		}
	}
}