using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Add_item_to_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, IStoreItems, IReadRequests, IItemTemplate
	{
		private const int BasketId = 999;
		private const int ItemId = 555;
		private const string ExpectedLocation = "expected location";
		private Request _itemStored;
		private readonly Request _itemFromRequest = new Request('Z', BasketId);
		private int _statusCode;
		private string _redirectLocation;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_itemStored = null;

			var handler = new Handler(this, this, this);

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
		public void Then_the_response_has_the_redirect_location_from_the_template()
		{
			Assert.That(_redirectLocation, Is.EqualTo(ExpectedLocation));
		}

		public Request From(HttpRequestBase httpRequest)
		{
			return _itemFromRequest;
		}

		public CreatedItem StoreItem(Request request)
		{
			_itemStored = request;
			return new CreatedItem(ItemId, BasketId);
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public override string RedirectLocation
		{
			set { _redirectLocation = value; }
		}

		public string CompleteWith(int basketId, int itemId)
		{
			Assert.That(basketId, Is.EqualTo(BasketId));
			Assert.That(itemId, Is.EqualTo(ItemId));
			return ExpectedLocation;
		}
	}

}