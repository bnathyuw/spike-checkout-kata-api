using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Data
{
	[TestFixture]
	public class When_a_new_basket_is_retrieved
	{
		private Basket _basket;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basketId = basketStore.CreateBasket();
			_basket = basketStore.GetBasket(new RetrieveBasketRequest(basketId));
		}

		[Test]
		public void Then_it_contains_nothing()
		{
			Assert.That(_basket.Contents, Is.Empty);
		}
	}
}