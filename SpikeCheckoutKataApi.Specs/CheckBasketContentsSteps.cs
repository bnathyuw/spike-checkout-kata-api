using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpikeCheckoutKataApi.Specs
{
	[Binding]
	public class CheckBasketContentsSteps
	{
		private readonly Browser _browser;
		private Uri _basketUrl;

		public CheckBasketContentsSteps(Browser browser)
		{
			_browser = browser;
		}

		[Given(@"I have a basket")]
		public async Task GivenIHaveABasket()
		{
			await _browser.CreateBasket();

			Assert.That(_browser.StatusCode, Is.EqualTo(HttpStatusCode.Created));

			_basketUrl = _browser.Location;
		}

		[When(@"I check my basket")]
		public async Task WhenICheckMyBasket()
		{
			await _browser.RetrieveBasket(_basketUrl);
		}

		[Then(@"I have nothing in my basket")]
		public async Task ThenIHaveNothingInMyBasket()
		{
			var basket = await _browser.ResponseAs<Basket>();

			Assert.That(basket.Contents, Is.Empty);
		}
	}
}
