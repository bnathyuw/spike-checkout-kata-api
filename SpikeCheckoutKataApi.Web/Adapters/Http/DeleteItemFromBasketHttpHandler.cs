using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class DeleteItemFromBasketHttpHandler
	{
		public static HttpHandlerWrapper CreateHandler()
		{
			return new HttpHandlerWrapper(new Handler(new ItemStore(), new RequestReader()));
		}
	}
}