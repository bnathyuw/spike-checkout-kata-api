using SpikeCheckoutKataApi.Web.Adapters.Data;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class Request
	{
		private readonly string _shopper;

		public Request(string shopper)
		{
			_shopper = shopper;
		}

		public BasketInStore ToBasketInStoreWithId(int id)
		{
			return new BasketInStore(id, _shopper);
		}
	}
}