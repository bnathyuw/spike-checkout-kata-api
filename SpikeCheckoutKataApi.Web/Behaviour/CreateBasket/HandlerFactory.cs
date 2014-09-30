using System.Text.RegularExpressions;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class HandlerFactory : IHandlerFactory
	{
		public IHandler CreateHandler()
		{
			return new Handler(new BasketStore(), new RequestReader(), new BasketTemplate());
		}

		public bool Matches(string requestType, string url)
		{
			return new Regex("^/baskets$").IsMatch(url) && requestType == "POST";
		}
	}
}