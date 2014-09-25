using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.CreateBasket
{
	public class CreateBasketHandler:IHttpHandler
	{
		private readonly BasketStore _basketStore;

		public CreateBasketHandler()
		{
			_basketStore = new BasketStore();
		}

		public void ProcessRequest(HttpContext context)
		{
			var basketId = _basketStore.CreateBasket();
			context.Response.StatusCode = (int) HttpStatusCode.Created;
			context.Response.RedirectLocation = "http://spike-checkout-kata-api.local/baskets/" + basketId;
		}

		public bool IsReusable { get { return false; } }
	}
}