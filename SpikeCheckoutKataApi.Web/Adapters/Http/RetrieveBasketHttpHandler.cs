using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class RetrieveBasketHttpHandler : HttpHandlerWrapper
	{
		public RetrieveBasketHttpHandler()
			: base(new Handler(new BasketStore(), new RequestReader()))
		{
		}
	}
}