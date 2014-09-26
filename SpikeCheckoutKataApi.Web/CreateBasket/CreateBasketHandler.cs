using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.CreateBasket
{
	public class CreateBasketHandler : IHandler
	{
		private readonly BasketStore _basketStore;

		public CreateBasketHandler()
		{
			_basketStore = new BasketStore();
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			var basketId = _basketStore.CreateBasket();
			httpResponse.StatusCode = (int)HttpStatusCode.Created;
			httpResponse.RedirectLocation = "http://spike-checkout-kata-api.local/baskets/" + basketId;
		}
	}
}