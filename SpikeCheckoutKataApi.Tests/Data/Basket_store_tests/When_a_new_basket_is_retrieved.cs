using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Data.Basket_store_tests
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
			_basket = basketStore.GetBasket(basketId);
		}

		[Test]
		public void Then_it_contains_nothing()
		{
			Assert.That(_basket.Contents, Is.Empty);
		}
	}
}