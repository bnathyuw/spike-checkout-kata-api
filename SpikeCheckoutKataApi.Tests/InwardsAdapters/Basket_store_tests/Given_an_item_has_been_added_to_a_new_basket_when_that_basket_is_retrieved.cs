using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Http.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.InwardsAdapters.Basket_store_tests
{
	[TestFixture]
	public class Given_an_item_has_been_added_to_a_new_basket_when_that_basket_is_retrieved
	{
		private Basket _basket;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basketId = basketStore.CreateBasket();
			basketStore.AddItemToBasket(new AddItemToBasketRequest(basketId, new ItemRequest {Code = 'A'}));
			_basket = basketStore.GetBasket(basketId);
		}

		[Test]
		public void Then_the_item_appears_in_the_basket()
		{
			Assert.That(_basket.Contents, Is.EquivalentTo(new[] {'A'}));
		}
	}
}