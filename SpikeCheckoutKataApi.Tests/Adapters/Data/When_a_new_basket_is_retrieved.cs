using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;
using CreateBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.Request;
using RetrieveBasketRequest = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.Request;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class When_a_new_basket_is_retrieved : IBasketTemplate
	{
		private IBasketResponse _basketResponse;
		private int _basketId;
		private const string Shopper = "Jones";

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basket = basketStore.CreateBasket(new CreateBasketRequest(Shopper));
			basket.CompleteTemplate(this);

			_basketResponse = basketStore.GetBasket(new RetrieveBasketRequest(_basketId));
		}

		[Test]
		public void Then_it_shows_the_shoppers_name()
		{
			Assert.That(_basketResponse.Shopper, Is.EqualTo(Shopper));
		}

		public string CompleteWith(int basketId)
		{
			_basketId = basketId;
			return null;
		}
	}
}