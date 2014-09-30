using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class CreateBasketHttpHandler
	{
		public static HttpHandlerWrapper CreateCreateBasketHttpHandler()
		{
			return new HttpHandlerWrapper(new Handler(new BasketStore(), new RequestReader(), new BasketTemplate()));
		}
	}
}