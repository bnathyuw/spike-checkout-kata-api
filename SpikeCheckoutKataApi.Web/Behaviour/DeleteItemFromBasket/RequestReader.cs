using System;
using System.Text.RegularExpressions;
using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public class RequestReader:IReadRequests{
		public Request From(HttpRequestBase request)
		{
			var regex = new Regex("^/baskets/(?<basketId>\\d+)/items/(?<itemId>\\d+)$");
			var match = regex.Match(request.Path);

			var basketId = Int32.Parse(match.Groups["basketId"].Value);
			var itemId = Int32.Parse(match.Groups["itemId"].Value);
			
			return new Request(basketId, itemId);
		}
	}
}