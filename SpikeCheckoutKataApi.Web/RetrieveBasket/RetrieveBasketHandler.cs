using System.Web;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public class RetrieveBasketHandler:IHandler
	{
		private readonly IGetBaskets _basketStore;
		private readonly IReadRetrieveBasketRequests _retrieveBasketRequestReader;

		public RetrieveBasketHandler(IGetBaskets basketStore, IReadRetrieveBasketRequests retrieveBasketRequestReader)
		{
			_basketStore = basketStore;
			_retrieveBasketRequestReader = retrieveBasketRequestReader;
		}

		public void ProcessRequest(HttpRequestBase httpRequestWrapper, HttpResponseBase httpResponse)
		{
			var getBasketRequest = _retrieveBasketRequestReader.Read(httpRequestWrapper);
			var basketResponse = _basketStore.GetBasket(getBasketRequest);
			httpResponse.WriteBody(basketResponse);
		}
	}
}