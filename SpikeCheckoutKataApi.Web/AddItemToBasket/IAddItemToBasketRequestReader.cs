using System.Web;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public interface IAddItemToBasketRequestReader
	{
		ItemRequest From(HttpRequestBase httpRequest);
	}
}