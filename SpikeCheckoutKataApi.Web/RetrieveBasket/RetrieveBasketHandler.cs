using System.Web;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public class RetrieveBasketHandler:IHandler
	{
		private readonly BasketStore _basketStore;
		private readonly RetrieveBasketRequestReader _retrieveBasketRequestReader;

		public RetrieveBasketHandler()
		{
			_basketStore = new BasketStore();
			_retrieveBasketRequestReader = new RetrieveBasketRequestReader();
		}

		public void ProcessRequest(HttpRequestBase httpRequestWrapper, HttpResponseBase httpResponse)
		{
			var getBasketRequest = _retrieveBasketRequestReader.Read(httpRequestWrapper);
			var basketResponse = _basketStore.GetBasket(getBasketRequest);
			httpResponse.WriteBody(basketResponse);
		}
	}
}