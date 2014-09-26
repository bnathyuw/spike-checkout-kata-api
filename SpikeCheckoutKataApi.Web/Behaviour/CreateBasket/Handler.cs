using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class Handler : IHandler
	{
		private readonly ICreateBaskets _basketStore;

		public Handler(ICreateBaskets basketStore)
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