using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;

namespace SpikeCheckoutKataApi.Tests.Behaviour.Delete_item_from_basket.Request_reader_tests
{
	[TestFixture]
	public class When_the_request_is_valid : HttpRequestBase
	{
		private const int BasketId = 666;
		private const int ItemId = 444;

		[Test]
		public void Then_the_item_can_be_read()
		{
			var requestReader = new RequestReader();
			var request = requestReader.From(this);

			Assert.That(request.Matches(ItemId, BasketId), Is.True);
		}

		public override string Path
		{
			get { return "/baskets/" + BasketId + "/items/" + ItemId; }
		}
	}
}