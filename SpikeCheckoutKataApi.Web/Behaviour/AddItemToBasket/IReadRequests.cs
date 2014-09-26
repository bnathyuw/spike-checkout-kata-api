using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public interface IReadRequests
	{
		Request From(HttpRequestBase httpRequest);
	}
}