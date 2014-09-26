using SpikeCheckoutKataApi.Web.CreateBasket;

namespace SpikeCheckoutKataApi.Web.Http
{
	public class CreateBasketHttpHandler : HttpHandlerWrapper
	{
		public CreateBasketHttpHandler()
			: base(new CreateBasketHandler())
		{
		}
	}
}