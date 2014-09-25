using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketHandler:IHttpHandler
	{
		private readonly BasketStore _basketStore;

		public AddItemToBasketHandler()
		{
			_basketStore = new BasketStore();
		}

		public void ProcessRequest(HttpContext context)
		{
			var request = AddItemToBasketRequest.From(context.Request);

			_basketStore.AddItemToBasket(request);
			
			context.Response.StatusCode = (int) HttpStatusCode.Created;
		}

		public bool IsReusable { get { return false; } }
	}
}