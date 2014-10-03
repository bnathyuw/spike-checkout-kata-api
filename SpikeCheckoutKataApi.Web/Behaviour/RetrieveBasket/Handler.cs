using System.Collections.Generic;
using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public interface IBasketResponse
	{
		IEnumerable<char> Contents { get; }
		string Shopper { get; }
		Basket WithContents(IEnumerable<char> contents);
	}

	public interface ISpecifyBasketToRetrieve
	{
		bool Matches(int basketId);
	}

	public interface IGetBaskets
	{
		IBasketResponse GetBasket(ISpecifyBasketToRetrieve request);
	}

	public interface IReadRequests
	{
		Request Read(HttpRequestBase httpRequestWrapper);
	}
	
	public class Handler : IHandler
	{
		private readonly IGetBaskets _basketStore;
		private readonly IReadRequests _requestReader;
		private readonly IFindItemsByBasket _itemStore;

		public Handler(IGetBaskets basketStore, IReadRequests requestReader, IFindItemsByBasket itemStore)
		{
			_basketStore = basketStore;
			_requestReader = requestReader;
			_itemStore = itemStore;
		}

		public void ProcessRequest(HttpRequestBase httpRequestWrapper, HttpResponseBase httpResponse)
		{
			var getBasketRequest = _requestReader.Read(httpRequestWrapper);
			var basket = _basketStore.GetBasket(getBasketRequest);
			var basketContents = (_itemStore).GetMatching(getBasketRequest);
			var basketResponse = (IBasketResponse) basket.WithContents(basketContents);
			httpResponse.StatusCode = (int) HttpStatusCode.OK;
			httpResponse.WriteBody(basketResponse);
		}
	}
}