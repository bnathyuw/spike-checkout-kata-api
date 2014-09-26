using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Specs.Support
{
	public static class Serializer
	{
		private static readonly JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();

		public static string Serialize(object entity)
		{
			return JavaScriptSerializer.Serialize(entity);
		}

		public static T Deserialize<T>(string content)
		{
			return JavaScriptSerializer.Deserialize<T>(content);
		}
	}
}