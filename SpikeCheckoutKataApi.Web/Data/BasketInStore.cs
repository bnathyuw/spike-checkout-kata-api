using System.Collections.Generic;
using SpikeCheckoutKataApi.Web.Http.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Data
{
	public class BasketInStore
	{
		private readonly int _id;
		private readonly List<char> _contents = new List<char>();

		public BasketInStore(int id)
		{
			_id = id;
		}

		public void AddItem(char item)
		{
			_contents.Add(item);
		}

		public Basket ToBasketResponse()
		{
			return new Basket(_contents.ToArray());
		}

		public bool WithId(int id)
		{
			return _id == id;
		}
	}
}