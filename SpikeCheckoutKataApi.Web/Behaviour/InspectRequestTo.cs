using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Web.Behaviour
{
	public static class InspectRequestTo
	{
		private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

		public static int GetBasketId(this HttpRequestBase request)
		{
			var regex = new Regex("^/baskets/(?<basketId>\\d+)");
			return Int32.Parse(regex.Match(request.Path).Groups["basketId"].Value);
		}

		public static int GetItemId(this HttpRequestBase request)
		{
			var regex = new Regex("^/baskets/(\\d+)/items/(?<itemId>\\d+)");
			return Int32.Parse(regex.Match(request.Path).Groups["itemId"].Value);
		}

		public static dynamic ReadBodyAsDynamic(this HttpRequestBase httpRequest)
		{
			var body = httpRequest.ReadBody();
			return Serializer.DeserializeObject(body);
		}

		private static string ReadBody(this HttpRequestBase httpRequest)
		{
			using (var stream = httpRequest.GetBufferlessInputStream())
			using (var reader = new StreamReader(stream))
				return reader.ReadToEnd();
		}
	}
}