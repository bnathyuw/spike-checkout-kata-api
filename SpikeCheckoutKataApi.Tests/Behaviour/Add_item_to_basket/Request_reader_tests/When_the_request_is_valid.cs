using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Add_item_to_basket.Request_reader_tests
{
	[TestFixture]
	public class When_the_request_is_valid : HttpRequestBase
	{
		private MemoryStream _stream;
		private StreamWriter _writer;
		private RequestReader _requestReader;
		private const char ItemCode = 'A';

		[SetUp]
		public void SetUp()
		{
			_stream = new MemoryStream();
			_writer = new StreamWriter(_stream);
			var serializer = new JavaScriptSerializer();
			var content = serializer.Serialize(new {Code = ItemCode});
			_writer.Write(content);
			_writer.Flush();
			_stream.Position = 0;
			_requestReader = new RequestReader();
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
			var itemRequest = _requestReader.From(this);
			Assert.That(itemRequest, Is.Not.Null);
		}

		public override Stream GetBufferlessInputStream()
		{
			return _stream;
		}

		public override string Path
		{
			get { return "/baskets/444"; }
		}
	}
}