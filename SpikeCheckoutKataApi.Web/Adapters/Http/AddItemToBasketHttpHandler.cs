using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class AddItemToBasketHttpHandler : HttpHandlerWrapper
	{
		public AddItemToBasketHttpHandler()
			: base(new Handler(new ItemStore(), new RequestReader()))
		{
		}
	}
}