using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Http
{
	public class RetrieveBasketHttpHandler : HttpHandlerWrapper
	{
		public RetrieveBasketHttpHandler()
			: base(new RetrieveBasketHandler(new BasketStore(), new RetrieveBasketRequestReader()))
		{
		}
	}
}