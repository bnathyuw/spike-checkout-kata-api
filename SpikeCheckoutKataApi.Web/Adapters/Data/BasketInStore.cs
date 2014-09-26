using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class BasketInStore
	{
		private readonly int _id;

		public BasketInStore(int id)
		{
			_id = id;
		}

		public BasketResponse ToResponseWithContents(IEnumerable<char> contents)
		{
			return new BasketResponse(contents.ToArray());
		}

		public bool Matching(Request request)
		{
			return request.Matches(_id);
		}
	}
}