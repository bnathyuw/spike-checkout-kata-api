using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Tests.Data
{
	[TestFixture]
	public class When_a_new_basket_is_retrieved
	{
		private BasketResponse _basketResponse;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			var basketId = basketStore.CreateBasket();
			_basketResponse = basketStore.GetBasket(new Request(basketId));
		}

		[Test]
		public void Then_it_contains_nothing()
		{
			Assert.That(_basketResponse.Contents, Is.Empty);
		}
	}
}