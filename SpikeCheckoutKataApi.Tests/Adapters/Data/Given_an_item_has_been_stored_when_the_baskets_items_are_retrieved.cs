using System.Collections.Generic;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;
using AddItemToBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.Request;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class Given_an_item_has_been_stored_when_the_baskets_items_are_retrieved : IBasketTemplate
	{
		private int _basketId;
		private IEnumerable<char> _basketContents;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basket = basketStore.CreateBasket(new CreateBasketRequest(null));
			basket.CompleteTemplate(this); 
			
			var itemStore = new ItemStore();

			itemStore.StoreItem(new AddItemToBasketRequest('A', _basketId));
			ISpecifyBasketToRetrieve request = new RetrieveBasketRequest(_basketId);
			_basketContents = new ItemStore().GetMatching(request);
		}

		[Test]
		public void Then_the_item_appears_in_the_basket()
		{
			Assert.That(_basketContents, Is.EquivalentTo(new[] { 'A' }));
		}

		public string CompleteWith(int basketId)
		{
			_basketId = basketId;
			return null;
		}
	}
}