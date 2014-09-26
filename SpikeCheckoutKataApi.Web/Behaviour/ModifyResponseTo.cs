using System.Web;
using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Web.Behaviour
{
	public static class ModifyResponseTo
	{
		private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

		public static void WriteBody(this HttpResponseBase httpResponse, object response)
		{
			httpResponse.Write(Serializer.Serialize(response));
		}
	}
}