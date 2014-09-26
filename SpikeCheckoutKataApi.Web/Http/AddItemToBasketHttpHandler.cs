using SpikeCheckoutKataApi.Web.AddItemToBasket;

namespace SpikeCheckoutKataApi.Web.Http
{
	public class AddItemToBasketHttpHandler : HttpHandlerWrapper
	{
		public AddItemToBasketHttpHandler()
			: base(new AddItemToBasketHandler())
		{
		}
	}
}