using System;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	internal class ItemRequestReader
	{
		private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

		public ItemRequest From(HttpRequest httpRequest)
		{
			using(var stream = httpRequest.GetBufferlessInputStream())
			using (var reader = new StreamReader(stream))
			{
				var body = reader.ReadToEnd();
				dynamic item = Serializer.DeserializeObject(body);
				var code = Char.Parse(item["Code"]);
				var basketId = httpRequest.GetBasketId();
				return new ItemRequest(code, basketId);
			}
		}
	}
}