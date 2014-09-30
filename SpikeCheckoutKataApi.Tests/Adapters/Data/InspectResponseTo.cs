using System;
using System.Text.RegularExpressions;
using CreateBasketResponse = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Response;
using AddItemToBasketResponse = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Response;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	public static class InspectResponseTo
	{
		public static int GetBasketId(this CreateBasketResponse response)
		{
			var regex = new Regex("^/baskets/(?<basketId>\\d+)");
			return Int32.Parse(regex.Match(response.GetLocation()).Groups["basketId"].Value);
		}

		public static int GetItemId(this AddItemToBasketResponse response)
		{
			var regex = new Regex("^/baskets/(?<basketId>\\d+)/items/(?<itemId>\\d+)");
			return Int32.Parse(regex.Match(response.GetLocation()).Groups["itemId"].Value);
		}
	}
}