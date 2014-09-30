using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;
using AddItemToBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Request;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using DeleteItemFromBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket.Request;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class Given_an_item_has_been_added_to_a_new_basket_when_that_basket_is_retrieved : IItemTemplate, IBasketTemplate
	{
		private BasketResponse _basketResponse;
		private int _itemId;
		private int _basketId;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();
			var itemStore = new ItemStore();

			var basket = basketStore.CreateBasket(new CreateBasketRequest(null));
			basket.CompleteTemplate(this);
			var item = itemStore.StoreItem(new AddItemToBasketRequest('A', _basketId));
			item.CompleteTemplate(this);
			itemStore.DeleteItem(new DeleteItemFromBasketRequest(_basketId, _itemId));
			_basketResponse = basketStore.GetBasket(new RetrieveBasketRequest(_basketId));
		}

		[Test]
		public void Then_the_item_does_not_appear_in_the_basket()
		{
			Assert.That(_basketResponse.Contents, Is.EquivalentTo(new char[] {}));
		}

		public string CompleteWith(int basketId, int itemId)
		{
			_itemId = itemId;
			return null;
		}

		public string CompleteWith(int basketId)
		{
			_basketId = basketId;
			return null;
		}
	}
}