using System.Web;

namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public class RetrieveBasketRequestReader : IReadRetrieveBasketRequests
	{
		public RetrieveBasketRequest Read(HttpRequestBase httpRequestWrapper)
		{
			var basketId = httpRequestWrapper.GetBasketId();
			return new RetrieveBasketRequest(basketId);
		}
	}
}