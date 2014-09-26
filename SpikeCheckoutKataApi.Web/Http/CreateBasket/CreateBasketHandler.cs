using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.CreateBasket
{
	public class CreateBasketHandler:IHttpHandler, IHandler
	{
		private readonly BasketStore _basketStore;

		public CreateBasketHandler()
		{
			_basketStore = new BasketStore();
		}

		public void ProcessRequest(HttpContext context)
		{
			ProcessRequest(new HttpRequestWrapper(context.Request), new HttpResponseWrapper(context.Response));
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			var basketId = _basketStore.CreateBasket();
			httpResponse.StatusCode = (int)HttpStatusCode.Created;
			httpResponse.RedirectLocation = "http://spike-checkout-kata-api.local/baskets/" + basketId;
		}

		public bool IsReusable { get { return false; } }
	}
}