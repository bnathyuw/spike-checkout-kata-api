using System.Web;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public interface IReadAddItemToBasketRequests
	{
		ItemRequest From(HttpRequestBase httpRequest);
	}
}