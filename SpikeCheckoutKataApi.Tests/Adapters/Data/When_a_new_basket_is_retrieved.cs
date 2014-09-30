using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class When_a_new_basket_is_retrieved
	{
		private BasketResponse _basketResponse;
		private const string Shopper = "Jones";

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basket = basketStore.CreateBasket(new CreateBasketRequest(Shopper));
			var basketId = basket.BasketId;
			_basketResponse = basketStore.GetBasket(new Request(basketId));
		}

		[Test]
		public void Then_it_contains_nothing()
		{
			Assert.That(_basketResponse.Contents, Is.Empty);
		}

		[Test]
		public void Then_it_shows_the_shoppers_name()
		{
			Assert.That(_basketResponse.Shopper, Is.EqualTo(Shopper));
		}
	}
}