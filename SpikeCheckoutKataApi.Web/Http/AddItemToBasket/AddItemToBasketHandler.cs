using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketHandler:IHttpHandler
	{
		private readonly ItemStore _itemStore;

		public AddItemToBasketHandler()
		{
			_itemStore = new ItemStore();
		}

		public void ProcessRequest(HttpContext context)
		{
			var request = AddItemToBasketRequest.From(context.Request);

			_itemStore.StoreItem(request);
			
			context.Response.StatusCode = (int) HttpStatusCode.Created;
		}

		public bool IsReusable { get { return false; } }
	}
}