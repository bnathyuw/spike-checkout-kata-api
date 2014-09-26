using SpikeCheckoutKataApi.Web.CreateBasket;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http
{
	public class CreateBasketHttpHandler : HttpHandlerWrapper
	{
		public CreateBasketHttpHandler()
			: base(new CreateBasketHandler(new BasketStore()))
		{
		}
	}
}