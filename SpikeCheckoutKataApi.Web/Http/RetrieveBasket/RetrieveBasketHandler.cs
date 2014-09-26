using System.Web;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http.AddItemToBasket;

namespace SpikeCheckoutKataApi.Web.Http.RetrieveBasket
{
	public class RetrieveBasketHandler : IHttpHandler, IHandler
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
			ProcessRequest(new HttpRequestWrapper(context.Request), new HttpResponseWrapper(context.Response));
		}

		public void ProcessRequest(HttpRequestBase httpRequestWrapper, HttpResponseBase httpResponse)
		{
			var getBasketRequest = _retrieveBasketRequestReader.Read(httpRequestWrapper);
			var basketResponse = _basketStore.GetBasket(getBasketRequest);
			httpResponse.WriteBody(basketResponse);
		}

		public bool IsReusable { get { return false; } }
	}
}