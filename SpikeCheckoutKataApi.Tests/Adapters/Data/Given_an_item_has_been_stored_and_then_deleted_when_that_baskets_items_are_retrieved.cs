using System.Collections.Generic;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using AddItemToBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Request;
using Request = SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket.Request;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class Given_an_item_has_been_stored_and_then_deleted_when_that_baskets_items_are_retrieved : IItemTemplate, IBasketTemplate
	{
		private int _itemId;
		private int _basketId;
		private IEnumerable<char> _basketContents;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basket = basketStore.CreateBasket(new CreateBasketRequest(null));
			basket.CompleteTemplate(this);

			var itemStore = new ItemStore();

			var item = itemStore.StoreItem(new AddItemToBasketRequest('A', _basketId));
			item.CompleteTemplate(this);

			itemStore.DeleteItem(new Request(_basketId, _itemId));

			_basketContents = itemStore.GetMatching(new RetrieveBasketRequest(_basketId));
		}

		[Test]
		public void Then_the_item_does_not_appear_in_the_basket()
		{
			Assert.That(_basketContents, Is.EquivalentTo(new char[] { }));
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