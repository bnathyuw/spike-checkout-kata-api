using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class RetrieveBasketHttpHandler
	{
		public static HttpHandlerWrapper CreateRetrieveBasketHttpHandler()
		{
			return new HttpHandlerWrapper(new Handler(new BasketStore(), new RequestReader()));
		}
	}
}