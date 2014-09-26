using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class Handler : IHandler
	{
		private readonly IStoreItems _itemStore;
		private readonly IReadRequests _readRequest;

		public Handler(IStoreItems itemStore, IReadRequests requestReader)
		{
			_itemStore = itemStore;
			_readRequest = requestReader;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			try
			{
				var request = _readRequest.From(httpRequest);

				var itemId = _itemStore.StoreItem(request);

				httpResponse.StatusCode = (int) HttpStatusCode.Created;
				httpResponse.RedirectLocation = string.Format("http://spike-checkout-kata-api.local/baskets/{0}/items/{1}", request.BasketId, itemId);
			}
			catch (ValidationException badRequestException)
			{
				httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
				httpResponse.WriteBody(badRequestException.ToError());
			}
		}
	}
}