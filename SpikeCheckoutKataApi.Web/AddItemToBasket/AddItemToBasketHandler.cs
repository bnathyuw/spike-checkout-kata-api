using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public class AddItemToBasketHandler : IHandler
	{
		private readonly IStoreItems _itemStore;
		private readonly IAddItemToBasketRequestReader _readAddItemToBasketRequest;

		public AddItemToBasketHandler(IStoreItems itemStore, IAddItemToBasketRequestReader requestReader)
		{
			_itemStore = itemStore;
			_readAddItemToBasketRequest = requestReader;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			try
			{
				var request = _readAddItemToBasketRequest.From(httpRequest);

				_itemStore.StoreItem(request);

				httpResponse.StatusCode = (int) HttpStatusCode.Created;
			}
			catch (ValidationException badRequestException)
			{
				httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
				httpResponse.WriteBody(badRequestException.ToError());
			}
		}
	}
}