using System.Web;

namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public interface IReadRetrieveBasketRequests
	{
		RetrieveBasketRequest Read(HttpRequestBase httpRequestWrapper);
	}
}