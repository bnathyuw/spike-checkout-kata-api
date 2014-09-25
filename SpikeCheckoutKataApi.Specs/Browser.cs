using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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

		public HttpStatusCode StatusCode
		{
			get { return _response.StatusCode; }
		}

		public Uri Location
		{
			get { return _response.Headers.Location; }
		}

		public async Task Post(Uri uri, object entity)
		{
			var content = Serializer.AsContent(entity);
			_response = await _client.PostAsync(uri, content);
		}

		public async Task Get(Uri uri)
		{
			_response = await _client.GetAsync(uri);
		}

		public async Task<T> ResponseAs<T>()
		{
			return await Serializer.Deserialize<T>(_response.Content);
		}
	}
}