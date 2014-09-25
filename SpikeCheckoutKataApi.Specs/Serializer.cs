using System.Net.Http;
using System.Threading.Tasks;
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

		public static async Task<T> Deserialize<T>(HttpContent httpContent)
		{
			var content = await httpContent.ReadAsStringAsync();
			return JavaScriptSerializer.Deserialize<T>(content);
		}
	}
}