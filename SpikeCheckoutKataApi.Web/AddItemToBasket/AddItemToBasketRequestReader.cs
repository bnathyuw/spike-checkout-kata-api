using System;
using System.Web;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public class AddItemToBasketRequestReader
	{
		public ItemRequest From(HttpRequestBase httpRequest)
		{
			var item = httpRequest.ReadBodyAsDynamic();

			var code = ReadCode(item);
			var basketId = httpRequest.GetBasketId();
			return new ItemRequest(code, basketId);
		}

		private static char ReadCode(dynamic item)
		{
			var value = item["Code"];
			char code;
			if (!Char.TryParse(value, out code))
			{
				throw new ValidationException("Invalid item code :" + value);
			}
			return code;
		}
	}
}