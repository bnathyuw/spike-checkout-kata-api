using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web;
using SpikeCheckoutKataApi.Web.Behaviour;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Add_item_to_basket.Request_reader_tests
{
	[TestFixture]
	public class When_the_request_is_invalid : HttpRequestBase
	{
		private MemoryStream _stream;
		private StreamWriter _writer;
		private RequestReader _requestReader;
		private const string InvalidItemCode = "123";
		private const int BasketId = 1;

		[SetUp]
		public void SetUp()
		{
			_stream = new MemoryStream();
			_writer = new StreamWriter(_stream);
			var serializer = new JavaScriptSerializer();
			
			var content = serializer.Serialize(new {Code = InvalidItemCode});
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
		public void Then_a_validation_exception_is_thrown()
		{
			var exception = Assert.Throws<ValidationException>(() => _requestReader.From(this));

			Assert.That(exception.Message, Is.StringContaining("Invalid").And.StringContaining("code").And.StringContaining(InvalidItemCode));
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