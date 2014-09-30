using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Create_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, ICreateBaskets, IReadRequests
	{
		private const int BasketId = 666;
		private int _statusCode;
		private string _redirectLocation;
		private readonly Request _basketFromRequest = new Request(null);
		private Request _basketStored;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var handler = new Handler(this, this);

			handler.ProcessRequest(null, this);
		}

		[Test]
		public void Then_the_basket_from_the_request_is_stored()
		{
			Assert.That(_basketStored, Is.EqualTo(_basketFromRequest));
		}

		[Test]
		public void Then_the_response_has_a_status_code_of_created()
		{
			Assert.That(_statusCode, Is.EqualTo((int)HttpStatusCode.Created));
		}

		[Test]
		public void Then_the_response_has_the_correct_redirect_location()
		{
			Assert.That(_redirectLocation, Is.StringContaining("/baskets/" + BasketId));
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public override string RedirectLocation
		{
			set { _redirectLocation = value; }
		}

		public int CreateBasket(Request request)
		{
			_basketStored = request;
			return BasketId;
		}

		public Request From(HttpRequestBase httpRequest)
		{
			return _basketFromRequest;
		}
	}
}