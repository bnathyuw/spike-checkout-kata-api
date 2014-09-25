using System.Net.Http;
using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Specs
{
	public static class Serializer
	{
		private static readonly JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();

		public static StringContent AsContent(object entity)
		{
			var basketJson = JavaScriptSerializer.Serialize(entity);
			return new StringContent(basketJson);
		}

		public static T Deserialize<T>(string content)
		{
			return JavaScriptSerializer.Deserialize<T>(content);
		}
	}
}