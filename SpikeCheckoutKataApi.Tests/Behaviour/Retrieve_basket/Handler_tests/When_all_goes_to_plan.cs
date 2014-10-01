using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Retrieve_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, IReadRequests, IGetBaskets
	{
		private int _statusCode;
		private string _body;
		private const int BasketId = 555;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var handler = new Handler(this, this);
			handler.ProcessRequest(null, this);
		}

		[Test]
		public void Then_the_response_has_a_status_code_of_ok()
		{
			Assert.That(_statusCode, Is.EqualTo((int)HttpStatusCode.OK));
		}

		[Test]
		public void Then_the_response_shows_the_contents_of_the_basket()
		{
			Assert.That(_body, Is.StringContaining("\"Contents\":[\"A\",\"B\",\"C\",\"D\",\"E\"]"));
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public Request Read(HttpRequestBase httpRequestWrapper)
		{
			return new Request(BasketId);
		}

		public IBasketResponse GetBasket(Request request)
		{
			return new Basket("ABCDE".ToCharArray(), null);
		}

		public override void Write(string body)
		{
			_body = body;
		}
	}
}