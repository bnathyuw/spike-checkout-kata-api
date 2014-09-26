using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Add_item_to_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, IStoreItems, IReadRequests
	{
		private const int BasketId = 999;
		private const int ItemId = 555;
		private Request _itemStored;
		private readonly Request _itemFromRequest = new Request('Z', BasketId);
		private int _statusCode;
		private string _redirectLocation;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_itemStored = null;

			var handler = new Handler(this, this);

			handler.ProcessRequest(null, this);
		}

		[Test]
		public void Then_the_item_from_the_request_is_stored()
		{
			Assert.That(_itemStored, Is.EqualTo(_itemFromRequest));
		}

		[Test]
		public void Then_the_response_has_a_status_code_of_created()
		{
			Assert.That(_statusCode, Is.EqualTo((int)HttpStatusCode.Created));
		}

		[Test]
		public void Then_the_response_has_the_correct_redirect_location()
		{
			Assert.That(_redirectLocation, Is.StringContaining("/baskets/" + BasketId + "/items/" + ItemId));
		}

		public Request From(HttpRequestBase httpRequest)
		{
			return _itemFromRequest;
		}

		public int StoreItem(Request request)
		{
			_itemStored = request;
			return ItemId;
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public override string RedirectLocation
		{
			set { _redirectLocation = value; }
		}
	}

}