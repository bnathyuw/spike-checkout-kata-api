using System.Net;
using System.Net.Http;

namespace SpikeCheckoutKataApi.Specs
{
	public class Browser
	{
		private readonly HttpClient _client;
		private HttpResponseMessage _response;

		public Browser()
		{
			_client = new HttpClient();
		}

		public void Get(string url)
		{
			var task = _client.GetAsync(url);
			task.Wait();
			_response = task.Result;
		}

		public HttpStatusCode StatusCode
		{
			get { return _response.StatusCode; }
		}
	}
}