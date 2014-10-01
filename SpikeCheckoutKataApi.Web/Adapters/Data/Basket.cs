using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class Basket : IBasketResponse
	{
		private readonly string _shopper;
		private readonly char[] _contents;

		public Basket(char[] contents, string shopper)
		{
			_shopper = shopper;
			_contents = contents;
		}

		public char[] Contents
		{
			get { return _contents; }
		}

		public string Shopper
		{
			get { return _shopper; }
		}
	}
}