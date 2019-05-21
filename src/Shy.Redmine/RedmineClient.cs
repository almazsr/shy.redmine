using System;
using System.Collections;
using System.Collections.Generic;
using Refit;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public class RedmineClient
	{
		private readonly IRedmineApiClient _apiClient;
		public string ApiKey { get; }

		public RedmineClient(string baseUri, string apiKey)
		{
			_apiClient = RestService.For<IRedmineApiClient>(baseUri);
			ApiKey = apiKey;
		}

		public class TicketGetEnumerator : IEnumerator<TicketGet>
		{
			private readonly List<TicketGet> _tickets;

			public TicketGetEnumerator()
			{
				_tickets = new List<TicketGet>();
			}

			public bool MoveNext()
			{
				throw new NotImplementedException();
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}

			public TicketGet Current { get; }

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				throw new NotImplementedException();
			}
		}

		public class TicketGetEnumerable : IEnumerable<TicketGet>
		{
			public IEnumerator<TicketGet> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public IEnumerable<TicketGet> EnumerateTickets(IdsFilter statusIds = null, IdsFilter trackerIds = null, 
			DateTime? updatedAtFrom = null,
			DateTime? updatedAtTo = null)
		{

		}
	}
}