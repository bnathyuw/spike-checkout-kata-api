using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Data
{
	public class BasketInStore
	{
		private readonly int _id;

		public BasketInStore(int id)
		{
			_id = id;
		}

		public Basket ToBasketWithContents(IEnumerable<char> contents)
		{
			return new Basket(contents.ToArray());
		}

		public bool Matching(RetrieveBasketRequest request)
		{
			return request.Matches(_id);
		}
	}
}