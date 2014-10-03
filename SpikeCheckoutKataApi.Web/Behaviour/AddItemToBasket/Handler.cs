using System;
using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{

	public interface IItemTemplate
	{
		string CompleteWith(int basketId, int itemId);
	}
	
	public interface ICompleteItemTemplates
	{
		string CompleteTemplate(IItemTemplate itemTemplate);
	}

	public interface ISpecifyItemToStore
	{
		T Create<T>(Func<char, int, T> create);
	}

	public interface IStoreItems
	{
		ICompleteItemTemplates StoreItem(ISpecifyItemToStore request);
	}

	public interface IReadRequests
	{
		Request From(HttpRequestBase httpRequest);
	}

	public class Handler : IHandler
	{
		private readonly IStoreItems _itemStore;
		private readonly IReadRequests _readRequest;
		private readonly IItemTemplate _itemTemplate;

		public Handler(IStoreItems itemStore, IReadRequests requestReader, IItemTemplate itemTemplate)
		{
			_itemStore = itemStore;
			_readRequest = requestReader;
			_itemTemplate = itemTemplate;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			try
			{
				var request = _readRequest.From(httpRequest);

				var item = _itemStore.StoreItem(request);

				httpResponse.StatusCode = (int) HttpStatusCode.Created;
				httpResponse.RedirectLocation =  item.CompleteTemplate(_itemTemplate);
			}
			catch (ValidationException badRequestException)
			{
				httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
				httpResponse.WriteBody(badRequestException.ToError());
			}
		}
	}
}