using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class RequestReader:IReadRequests
	{
		public Request From(HttpRequestBase httpRequest)
		{
			var item = httpRequest.ReadBodyAsDynamic();

			var shopper = ReadShopper(item);
			return new Request(shopper);
		}

		private static string ReadShopper(dynamic item)
		{
			return item["Shopper"];
		}
	}
}