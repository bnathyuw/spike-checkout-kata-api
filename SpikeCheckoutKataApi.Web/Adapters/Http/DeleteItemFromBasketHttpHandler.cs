using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class DeleteItemFromBasketHttpHandler : HttpHandlerWrapper
	{
		public DeleteItemFromBasketHttpHandler()
			: base(new Handler(new ItemStore(), new RequestReader()))
		{
		}
	}
}