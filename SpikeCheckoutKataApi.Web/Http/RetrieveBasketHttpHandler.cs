using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Http
{
	public class RetrieveBasketHttpHandler : HttpHandlerWrapper
	{
		public RetrieveBasketHttpHandler()
			: base(new RetrieveBasketHandler())
		{
		}
	}
}