using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.RetrieveBasket
{
	public class RetrieveBasketHandler : IHttpHandler
	{
		private readonly BasketStore _basketStore;
		private readonly RetrieveBasketRequestReader _retrieveBasketRequestReader;

		public RetrieveBasketHandler()
		{
			_basketStore = new BasketStore();
			_retrieveBasketRequestReader = new RetrieveBasketRequestReader();
		}

		public void ProcessRequest(HttpContext context)
		{
			var getBasketRequest = _retrieveBasketRequestReader.Read(new HttpRequestWrapper(context.Request));

			var basketResponse = _basketStore.GetBasket(getBasketRequest);
			
			context.Response.WriteBody(basketResponse);
		}

		public bool IsReusable { get { return false; } }
	}
}