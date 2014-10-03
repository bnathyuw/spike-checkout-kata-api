using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Create_basket.Request_reader_tests
{
	[TestFixture]
	public class When_the_request_is_valid : HttpRequestBase
	{
		private MemoryStream _stream;
		private StreamWriter _writer;
		private RequestReader _requestReader;
		private ISpecifyBasketToStore _request;
		private const string Shopper = "Smith";

		[SetUp]
		public void SetUp()
		{
			_stream = new MemoryStream();
			_writer = new StreamWriter(_stream);
			var serializer = new JavaScriptSerializer();
			var content = serializer.Serialize(new { Shopper });
			_writer.Write(content);
			_writer.Flush();
			_stream.Position = 0;
			_requestReader = new RequestReader();

			_request = _requestReader.From(this);
		}

		[TearDown]
		public void TearDown()
		{
			_writer.Dispose();
			_stream.Dispose();
		}

		[Test]
		public void Then_the_item_can_be_read()
		{
			Assert.That(_request, Is.Not.Null);
		}

		public override Stream GetBufferlessInputStream()
		{
			return _stream;
		}

		public override string Path
		{
			get { return "/baskets"; }
		}
	}
}