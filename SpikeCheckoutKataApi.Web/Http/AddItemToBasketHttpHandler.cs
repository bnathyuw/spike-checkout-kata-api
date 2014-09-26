using SpikeCheckoutKataApi.Web.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http
{
	public class AddItemToBasketHttpHandler : HttpHandlerWrapper
	{
		public AddItemToBasketHttpHandler()
			: base(new AddItemToBasketHandler(new ItemStore(), new AddItemToBasketRequestReader()))
		{
		}
	}
}