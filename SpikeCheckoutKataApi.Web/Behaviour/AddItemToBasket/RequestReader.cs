using System;
using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class RequestReader : IReadRequests
	{
		public Request From(HttpRequestBase httpRequest)
		{
			var item = httpRequest.ReadBodyAsDynamic();

			var code = ReadCode(item);
			var basketId = httpRequest.GetBasketId();
			return new Request(code, basketId);
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