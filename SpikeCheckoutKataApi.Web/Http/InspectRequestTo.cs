using System.Text.RegularExpressions;
using System.Web;

namespace SpikeCheckoutKataApi.Web.Http
{
	public static class InspectRequestTo
	{
		public static int GetBasketId(this HttpRequest request)
		{
			var regex = new Regex("^/baskets/(?<Id>\\d+)$");
			return int.Parse(regex.Match(request.Path).Groups["Id"].Value);
		}
	}
}