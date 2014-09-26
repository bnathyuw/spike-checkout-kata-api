using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public interface IReadRequests
	{
		Request From(HttpRequestBase request);
	}
}