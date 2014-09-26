using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class CreateBasketHttpHandler : HttpHandlerWrapper
	{
		public CreateBasketHttpHandler()
			: base(new Handler(new BasketStore()))
		{
		}
	}
}