using System;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpikeCheckoutKataApi.Specs
{
	[Binding]
	public class CheckBasketContentsSteps
	{
		private readonly Browser _browser;
		private Uri _basketUri;

		public CheckBasketContentsSteps(Browser browser)
		{
			_browser = browser;
		}

		[Given(@"I have a basket")]
		public void GivenIHaveABasket()
		{
			_browser.CreateBasket().Wait();

			Assert.That(_browser.StatusCode, Is.EqualTo(HttpStatusCode.Created));

			_basketUri = _browser.Location;
		}

		[When(@"I check my basket")]
		public void WhenICheckMyBasket()
		{
			_browser.RetrieveBasket(_basketUri).Wait();
		}

		[Then(@"I have nothing in my basket")]
		public void ThenIHaveNothingInMyBasket()
		{
			var basket = _browser.ResponseAs<Basket>();

			Assert.That(basket.Contents, Is.Empty);
		}

		[Given(@"I add ([ABCD]+) to my basket")]
		public void GivenIAddItemsToMyBasket(string items)
		{
			foreach (var item in items)
			{
				_browser.AddToBasket(_basketUri, item).Wait();
			}

			Assert.That(_browser.StatusCode, Is.EqualTo(HttpStatusCode.Created));
		}

		[Then(@"my basket contains ([ABCD]+)")]
		public void ThenMyBasketContainsItems(string items)
		{
			var basket = _browser.ResponseAs<Basket>();

			Assert.That(basket.Contents, Is.EquivalentTo(items));
		}

	}
}
