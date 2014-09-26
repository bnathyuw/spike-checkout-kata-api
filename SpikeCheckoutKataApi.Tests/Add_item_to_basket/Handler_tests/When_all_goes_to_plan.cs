using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Add_item_to_basket.Handler_tests
{
	[TestFixture]
	public class When_all_goes_to_plan : IStoreItems, IAddItemToBasketRequestReader
	{
		private ItemRequest _itemStored;
		private readonly ItemRequest _itemFromRequest = new ItemRequest('Z', 999);
		private AddItemToBasketHandler _handler;
		private Response _response;
		private Request _request;

		[SetUp]
		public void SetUp()
		{
			_itemStored = null;

			_handler = new AddItemToBasketHandler(this, this);

			_response = new Response();
			_request = new Request();
			_handler.ProcessRequest(_request, _response);
		}

		[Test]
		public void Then_the_item_from_the_request_is_stored()
		{
			Assert.That(_itemStored, Is.EqualTo(_itemFromRequest));
		}

		[Test]
		public void Then_the_response_has_a_status_code_of_created()
		{
			Assert.That(_response.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
		}

		public ItemRequest From(HttpRequestBase httpRequest)
		{
			Assert.That(httpRequest, Is.EqualTo(_request), "httpRequest not recognised");
			return _itemFromRequest;
		}

		public void StoreItem(ItemRequest itemRequest)
		{
			_itemStored = itemRequest;
		}

		private class Response : HttpResponseBase
		{
			public override int StatusCode { get; set; }
		}

		private class Request : HttpRequestBase
		{
		}
	}

}