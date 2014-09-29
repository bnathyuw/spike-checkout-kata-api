using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class Given_an_item_has_been_added_to_a_new_basket_and_then_delete_when_that_basket_is_retrieved
	{
		private BasketResponse _basketResponse;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();
			var itemStore = new ItemStore();

			var basketId = basketStore.CreateBasket();
			itemStore.StoreItem(new Web.Behaviour.AddItemToBasket.Request('A', basketId));
			_basketResponse = basketStore.GetBasket(new Request(basketId));
		}

		[Test]
		public void Then_the_item_appears_in_the_basket()
		{
			Assert.That(_basketResponse.Contents, Is.EquivalentTo(new[] { 'A' }));
		}
	}
}