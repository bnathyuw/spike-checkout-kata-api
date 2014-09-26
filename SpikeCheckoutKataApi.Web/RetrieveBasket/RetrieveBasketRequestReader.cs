using System.Web;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public class RetrieveBasketRequestReader
	{
		public RetrieveBasketRequest Read(HttpRequestBase httpRequestWrapper)
		{
			var basketId = httpRequestWrapper.GetBasketId();
			return new RetrieveBasketRequest(basketId);
		}
	}
}