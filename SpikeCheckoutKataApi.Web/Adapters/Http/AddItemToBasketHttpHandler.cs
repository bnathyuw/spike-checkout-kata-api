using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class AddItemToBasketHttpHandler
	{
		public static HttpHandlerWrapper CreateAddItemToBasketHttpHandler()
		{
			return new HttpHandlerWrapper(new Handler(new ItemStore(), new RequestReader(), new ItemTemplate()));
		}
	}
}