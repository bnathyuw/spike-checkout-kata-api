using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public interface IReadRequests
	{
		Request From(HttpRequestBase httpRequest);
	}
}