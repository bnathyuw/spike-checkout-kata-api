using System.Web;
using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Web
{
	public class RetrieveBasketHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			var javaScriptSerializer = new JavaScriptSerializer();
			var contents = javaScriptSerializer.Serialize(new {Id = "1", Contents = new char[]{}});
			context.Response.Write(contents);
		}

		public bool IsReusable { get { return false; } }
	}
}