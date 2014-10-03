using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Create_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, ICreateBaskets, IReadRequests, IBasketTemplate
	{
		private const int BasketId = 666;
		private const string ExpectedLocation = "expected location";
		private int _statusCode;
		private string _redirectLocation;
		private readonly Request _basketFromRequest = new Request(null);
		private ISpecifyBasketToStore _basketStored;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var handler = new Handler(this, this, this);

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
		public void Then_the_response_has_the_redirect_location_from_the_template()
		{
			Assert.That(_redirectLocation, Is.EqualTo(ExpectedLocation));
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public override string RedirectLocation
		{
			set { _redirectLocation = value; }
		}

		public ICompleteBasketTemplates CreateBasket(ISpecifyBasketToStore request)
		{
			_basketStored = request;
			return new CreatedBasket(BasketId);
		}

		public Request From(HttpRequestBase httpRequest)
		{
			return _basketFromRequest;
		}

		public string CompleteWith(int basketId)
		{
			Assert.That(basketId, Is.EqualTo(BasketId));
			return ExpectedLocation;
		}
	}
}