using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Http.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Http.Item_request_reader_tests
{
	[TestFixture]
	public class When_the_request_is_valid : HttpRequestBase
	{
		private MemoryStream _stream;
		private StreamWriter _writer;
		private AddItemToBasketRequestReader _requestReader;
		private const char ItemCode = 'A';
		private const int BasketId = 1;

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
			_requestReader = new AddItemToBasketRequestReader();
		}

		[TearDown]
		public void TearDown()
		{
			_writer.Dispose();
			_stream.Dispose();
		}

		[Test]
		public void Then_the_item_is_read_correctly()
		{
			var itemRequest = _requestReader.From(this);
			Assert.That(itemRequest, Is.EqualTo(new ItemRequest(ItemCode, BasketId)));
		}

		public override Stream GetBufferlessInputStream()
		{
			return _stream;
		}

		public override string Path
		{
			get { return "/baskets/" + BasketId; }
		}
	}
}