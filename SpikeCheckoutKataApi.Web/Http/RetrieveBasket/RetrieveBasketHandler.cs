using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.RetrieveBasket
{
	public class RetrieveBasketHandler : IHttpHandler
	{
		private readonly BasketStore _basketStore;

		public RetrieveBasketHandler()
		{
			_basketStore = new BasketStore();
		}

		public void ProcessRequest(HttpContext context)
		{
			var id = new HttpRequestWrapper(context.Request).GetBasketId();
			var basketResponse = _basketStore.GetBasket(id);
			context.Response.WriteBody(basketResponse);
		}

		public bool IsReusable { get { return false; } }
	}
}