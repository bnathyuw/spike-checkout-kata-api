using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public interface IStoreItems
	{
		CreatedItem StoreItem(Request request);
	}

	public interface IReadRequests
	{
		Request From(HttpRequestBase httpRequest);
	}

	public class Handler : IHandler
	{
		private readonly IStoreItems _itemStore;
		private readonly IReadRequests _readRequest;
		private readonly IItemTemplate _itemTemplate;

		public Handler(IStoreItems itemStore, IReadRequests requestReader, IItemTemplate itemTemplate)
		{
			_itemStore = itemStore;
			_readRequest = requestReader;
			_itemTemplate = itemTemplate;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			try
			{
				var request = _readRequest.From(httpRequest);

				var item = _itemStore.StoreItem(request);

				httpResponse.StatusCode = (int) HttpStatusCode.Created;
				httpResponse.RedirectLocation =  item.CompleteTemplate(_itemTemplate);
			}
			catch (ValidationException badRequestException)
			{
				httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
				httpResponse.WriteBody(badRequestException.ToError());
			}
		}
	}
}