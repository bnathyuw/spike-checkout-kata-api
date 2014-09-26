using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public class RequestReader : IReadRequests
	{
		public Request Read(HttpRequestBase httpRequestWrapper)
		{
			var basketId = httpRequestWrapper.GetBasketId();
			return new Request(basketId);
		}
	}
}