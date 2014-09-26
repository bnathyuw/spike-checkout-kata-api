using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpikeCheckoutKataApi.Specs.Support
{
	public class Browser
	{
		private readonly HttpClient _client;
		private HttpResponseMessage _response;
		private string _body;

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
			var contentText = Serializer.Serialize(entity);
			Console.WriteLine("/\nPOST {0}\n{1}\n\\", uri, contentText);
			_response = await _client.PostAsync(uri, new StringContent(contentText));
			Console.WriteLine("/\n{0} {1}\n{2}", (int)_response.StatusCode, _response.StatusCode, _response.Headers);
			_body = await _response.Content.ReadAsStringAsync();
			Console.WriteLine("{0}\n\\", _body);
		}

		public async Task Get(Uri uri)
		{
			Console.WriteLine("/\nGET {0}\n\\", uri);
			_response = await _client.GetAsync(uri);
			Console.WriteLine("/\n{0} {1}\n{2}", (int)_response.StatusCode, _response.StatusCode, _response.Headers);
			_body = await _response.Content.ReadAsStringAsync();
			Console.WriteLine("{0}\n\\", _body);
		}

		public T ResponseAs<T>()
		{
			return Serializer.Deserialize<T>(_body);
		}

		public async Task Delete(Uri uri)
		{
			Console.WriteLine("/\nDELETE {0}\n\\", uri);
			_response = await _client.DeleteAsync(uri);
			Console.WriteLine("/\n{0} {1}\n{2}", (int)_response.StatusCode, _response.StatusCode, _response.Headers);
			_body = await _response.Content.ReadAsStringAsync();
			Console.WriteLine("{0}\n\\", _body);
		}
	}
}