using System.Net;
using System.Web;
using NUnit.Framework;
using SpikeCheckoutKataApi.Web.Behaviour;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Tests.Add_item_to_basket.Handler_tests
{
	[TestFixture]
	public class When_the_request_is_invalid : HttpResponseBase, IReadRequests
	{
		private int _statusCode;
		private string _body;
		private const string ExpectedValidationMessage = "Validation exception message";

		[SetUp]
		public void SetUp()
		{
			var handler = new Handler(null, this);

			handler.ProcessRequest(null, this);
		}

		[Test]
		public void Then_the_response_has_a_status_code_of_bad_request()
		{
			Assert.That(_statusCode, Is.EqualTo((int)HttpStatusCode.BadRequest));
		}

		[Test]
		public void Then_the_body_should_contain_the_validation_message()
		{
			Assert.That(_body, Is.StringContaining(ExpectedValidationMessage));
		}

		public Request From(HttpRequestBase httpRequest)
		{
			throw new ValidationException(ExpectedValidationMessage);
		}

		public override int StatusCode
		{
			set { _statusCode = value; }
		}

		public override void Write(string body)
		{
			_body = body;
		}
	}

}