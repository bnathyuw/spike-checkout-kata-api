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

				var item = _itemStore.StoreItem(request);

				httpResponse.StatusCode = (int) HttpStatusCode.Created;
				httpResponse.RedirectLocation = "http://spike-checkout-kata-api.local" + item.GetLocation();
			}
			catch (ValidationException badRequestException)
			{
				httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
				httpResponse.WriteBody(badRequestException.ToError());
			}
		}
	}
}