using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Retrieve_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, IReadRetrieveBasketRequests, IGetBaskets
	{
		private int _statusCode;
		private string _body;
		private const int BasketId = 555;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var handler = new RetrieveBasketHandler(this, this);
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
			Assert.That(_body, Is.StringContaining("{\"Contents\":[\"A\",\"B\",\"C\",\"D\",\"E\"]}"));
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public RetrieveBasketRequest Read(HttpRequestBase httpRequestWrapper)
		{
			return new RetrieveBasketRequest(BasketId);
		}

		public Basket GetBasket(RetrieveBasketRequest request)
		{
			return new Basket("ABCDE".ToCharArray());
		}

		public override void Write(string body)
		{
			_body = body;
		}
	}
}