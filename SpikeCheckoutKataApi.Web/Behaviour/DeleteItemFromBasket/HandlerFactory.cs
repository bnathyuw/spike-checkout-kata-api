using System.Text.RegularExpressions;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public class HandlerFactory : IHandlerFactory
	{
		public IHandler CreateHandler()
		{
			return new Handler(new ItemStore(), new RequestReader());
		}

		public bool Matches(string requestType, string url)
		{
			return new Regex("^/baskets/(\\d+)/items/(\\d+)$").IsMatch(url) && requestType == "DELETE";
		}
	}
}