using System;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class Request
	{
		private readonly string _shopper;

		public Request(string shopper)
		{
			_shopper = shopper;
		}

		public T Create<T>(Func<string, T> create)
		{
			return create(_shopper);
		}
	}
}