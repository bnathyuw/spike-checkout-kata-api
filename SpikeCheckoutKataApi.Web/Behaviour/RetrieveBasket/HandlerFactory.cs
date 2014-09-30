using System.Text.RegularExpressions;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public class HandlerFactory : IHandlerFactory
	{
		public IHandler CreateHandler()
		{
			return new Handler(new BasketStore(), new RequestReader());
		}

		public bool Matches(string requestType, string url)
		{
			return new Regex("^/baskets/(\\d+)$").IsMatch(url) && requestType == "GET";
		}
	}
}