using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public interface ICheckBasketMatches
	{
		bool Matches(int basketId);
	}

	public interface IFindItemsByBasket
	{
		IEnumerable<char> GetMatching(ICheckBasketMatches basket);
	}
	
	public class BasketStore : IGetBaskets, ICreateBaskets
	{
		private static int _currentId;
		private static readonly List<BasketInStore> Baskets = new List<BasketInStore>();
		private readonly IFindItemsByBasket _itemStore = new ItemStore();

		public IBasketResponse GetBasket(ISpecifyBasketToRetrieve request)
		{
			var basketInStore = Baskets.Single(b => b.Matches(request.Matches));
			var basketContents = _itemStore.GetMatching(basketInStore);
			return basketInStore.Create((id, shopper) => new Basket(basketContents, shopper));
		}

		public ICompleteBasketTemplates CreateBasket(ISpecifyBasketToStore request)
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