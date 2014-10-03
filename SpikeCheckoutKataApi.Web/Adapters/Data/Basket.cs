using System.Collections.Generic;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class Basket : IBasketResponse
	{
		private readonly string _shopper;
		private readonly IEnumerable<char> _contents;

		public Basket(string shopper)
		{
			_shopper = shopper;
		}

		public Basket(IEnumerable<char> contents, string shopper)
		{
			_shopper = shopper;
			_contents = contents;
		}

		public Basket WithContents(IEnumerable<char> contents)
		{
			return new Basket(contents, _shopper);
		}

		public IEnumerable<char> Contents
		{
			get { return _contents; }
		}

		public string Shopper
		{
			get { return _shopper; }
		}
	}
}