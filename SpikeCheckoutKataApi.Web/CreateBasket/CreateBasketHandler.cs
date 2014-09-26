using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.CreateBasket
{
	public class CreateBasketHandler : IHandler
	{
		private readonly ICreateBaskets _basketStore;

		public CreateBasketHandler(ICreateBaskets basketStore)
		{
			_basketStore = basketStore;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			var basketId = _basketStore.CreateBasket();
			httpResponse.StatusCode = (int)HttpStatusCode.Created;
			httpResponse.RedirectLocation = "http://spike-checkout-kata-api.local/baskets/" + basketId;
		}
	}
}