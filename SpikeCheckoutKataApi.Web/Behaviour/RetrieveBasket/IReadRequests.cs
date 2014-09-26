using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public interface IReadRequests
	{
		Request Read(HttpRequestBase httpRequestWrapper);
	}
}