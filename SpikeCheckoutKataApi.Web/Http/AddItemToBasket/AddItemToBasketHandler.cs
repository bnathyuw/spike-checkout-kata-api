using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketHandler:IHttpHandler
	{
		private readonly ItemStore _itemStore;
		private readonly AddItemToBasketRequestReader _readAddItemToBasketRequest;

		public AddItemToBasketHandler()
		{
			_itemStore = new ItemStore();
			_readAddItemToBasketRequest = new AddItemToBasketRequestReader();
		}

		public void ProcessRequest(HttpContext context)
		{
			try
			{
				var request = _readAddItemToBasketRequest.From(new HttpRequestWrapper(context.Request));

				_itemStore.StoreItem(request);

				context.Response.StatusCode = (int) HttpStatusCode.Created;
			}
			catch (ValidationException badRequestException)
			{
				context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
				context.Response.WriteBody(badRequestException.ToError());
			}
		}

		public bool IsReusable { get { return false; } }
	}
}