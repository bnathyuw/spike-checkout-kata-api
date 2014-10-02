using System.Collections.Generic;
using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public interface IBasketResponse
	{
		IEnumerable<char> Contents { get; }
		string Shopper { get; }
	}

	public interface IGetBaskets
	{
		IBasketResponse GetBasket(Request request);
	}

	public interface IReadRequests
	{
		Request Read(HttpRequestBase httpRequestWrapper);
	}
	
	public class Handler : IHandler
	{
		private readonly IGetBaskets _basketStore;
		private readonly IReadRequests _requestReader;

		public Handler(IGetBaskets basketStore, IReadRequests requestReader)
		{
			_basketStore = basketStore;
			_requestReader = requestReader;
		}

		public void ProcessRequest(HttpRequestBase httpRequestWrapper, HttpResponseBase httpResponse)
		{
			var getBasketRequest = _requestReader.Read(httpRequestWrapper);
			var basketResponse = _basketStore.GetBasket(getBasketRequest);
			httpResponse.StatusCode = (int) HttpStatusCode.OK;
			httpResponse.WriteBody(basketResponse);
		}
	}
}