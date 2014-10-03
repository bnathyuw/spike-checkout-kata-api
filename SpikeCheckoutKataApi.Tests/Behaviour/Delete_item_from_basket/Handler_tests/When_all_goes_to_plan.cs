using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Delete_item_from_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : HttpResponseBase, IDeleteItemsFromBaskets, IReadRequests
	{
		private int _statusCode;
		private ISpecifyItemToDelete _itemDeleted;
		private Request _request;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_request = new Request(666, 555);
			var handler = new Handler(this, this);
			handler.ProcessRequest(null, this);
		}

		[Test]
		public void Then_the_item_should_be_deleted()
		{
			Assert.That(_itemDeleted, Is.EqualTo(_request));
		}
		
		[Test]
		public void Then_the_response_has_a_status_code_of_ok()
		{
			Assert.That(_statusCode, Is.EqualTo((int)HttpStatusCode.OK));
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public void DeleteItem(ISpecifyItemToDelete request)
		{
			_itemDeleted = request;
		}

		public Request From(HttpRequestBase request)
		{
			return _request;
		}
	}
}