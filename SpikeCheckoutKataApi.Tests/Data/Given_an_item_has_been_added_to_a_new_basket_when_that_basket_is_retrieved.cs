using NUnit.Framework;
using SpikeCheckoutKataApi.Web.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Data
{
	[TestFixture]
	public class Given_an_item_has_been_added_to_a_new_basket_when_that_basket_is_retrieved
	{
		private Basket _basket;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();
			var itemStore = new ItemStore();

			var basketId = basketStore.CreateBasket();
			itemStore.StoreItem(new ItemRequest ('A', basketId));
			_basket = basketStore.GetBasket(new RetrieveBasketRequest(basketId));
		}

		[Test]
		public void Then_the_item_appears_in_the_basket()
		{
			Assert.That(_basket.Contents, Is.EquivalentTo(new[] {'A'}));
		}
	}
}