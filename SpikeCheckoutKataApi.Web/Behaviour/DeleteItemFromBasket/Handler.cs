using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public class Handler:IHandler
	{
		private readonly IDeleteItemsFromBaskets _deleteItemsFromBaskets;
		private readonly IReadRequests _readRequest;

		public Handler(IDeleteItemsFromBaskets deleteItemsFromBaskets, IReadRequests readRequest)
		{
			_deleteItemsFromBaskets = deleteItemsFromBaskets;
			_readRequest = readRequest;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			var request = _readRequest.From(httpRequest);
			_deleteItemsFromBaskets.DeleteItem(request);
			httpResponse.StatusCode = (int) HttpStatusCode.OK;
		}
	}
}