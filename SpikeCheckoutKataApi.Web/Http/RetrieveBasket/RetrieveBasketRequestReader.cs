using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.RetrieveBasket
{
	public class RetrieveBasketRequestReader
	{
		public RetrieveBasketRequest Read(HttpRequestWrapper httpRequestWrapper)
		{
			var basketId = httpRequestWrapper.GetBasketId();
			return new RetrieveBasketRequest(basketId);
		}
	}
}