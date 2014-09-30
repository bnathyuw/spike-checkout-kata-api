using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Tests.Adapters.Data
{
	[TestFixture]
	public class When_a_basket_is_created
	{
		private int _basketId;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var basketStore = new BasketStore();

			_basketId = basketStore.CreateBasket(new Request(null));
		}

		[Test]
		public void The_id_returned_is_greater_than_zero()
		{
			Assert.That(_basketId, Is.GreaterThan(0));
		}
	}
}