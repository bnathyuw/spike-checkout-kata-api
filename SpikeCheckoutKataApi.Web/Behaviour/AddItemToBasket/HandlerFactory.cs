using System.Text.RegularExpressions;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class HandlerFactory : IHandlerFactory
	{
		public IHandler CreateHandler()
		{
			return new Handler(new ItemStore(), new RequestReader(), new ItemTemplate());
		}

		public bool Matches(string requestType, string url)
		{
			return new Regex("^/baskets/(\\d+)/items$").IsMatch(url) && requestType == "POST";
		}
	}
}