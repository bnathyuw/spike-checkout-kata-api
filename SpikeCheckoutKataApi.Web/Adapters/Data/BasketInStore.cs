namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public delegate T CreateFromBasketInStore<out T>(int basketId, string shopper);

	public delegate bool MatchesBasketInStore(int id);

	public class BasketInStore
	{
		private readonly int _basketId;
		private readonly string _shopper;

		public BasketInStore(int basketId, string shopper)
		{
			_basketId = basketId;
			_shopper = shopper;
		}

		public bool Matches(MatchesBasketInStore matches)
		{
			return matches(_basketId);
		}

		public T Create<T>(CreateFromBasketInStore<T> create)
		{
			return create(_basketId, _shopper);
		}

		public bool Matches(int basketId)
		{
			return _basketId == basketId;
		}
	}
}