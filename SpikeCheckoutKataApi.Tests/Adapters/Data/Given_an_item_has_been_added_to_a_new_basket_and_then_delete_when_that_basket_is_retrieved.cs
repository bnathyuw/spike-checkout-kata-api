using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using AddItemToBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Request;

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

			var createBasketResponse = basketStore.CreateBasket(new CreateBasketRequest(null));
			itemStore.StoreItem(new AddItemToBasketRequest('A', createBasketResponse.BasketId));
			_basketResponse = basketStore.GetBasket(new RetrieveBasketRequest(createBasketResponse.BasketId));
		}

		[Test]
		public void Then_the_item_appears_in_the_basket()
		{
			Assert.That(_basketResponse.Contents, Is.EquivalentTo(new[] { 'A' }));
		}
	}
}