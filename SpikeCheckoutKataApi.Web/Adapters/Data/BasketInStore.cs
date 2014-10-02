using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public delegate T CreateFromBasketInStore<out T>(int basketId, string shopper);

	public class BasketInStore
	{
		private readonly int _id;
		private readonly string _shopper;

		public BasketInStore(int id, string shopper)
		{
			_id = id;
			_shopper = shopper;
		}

		public bool Matching(Request request)
		{
			return request.Matches(_id);
		}

		public T Create<T>(CreateFromBasketInStore<T> create)
		{
			return create(_id, _shopper);
		}

		public bool Matching(int basketId)
		{
			return _id == basketId;
		}
	}
}