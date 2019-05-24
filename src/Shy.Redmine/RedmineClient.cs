using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AsyncEnumerable;
using Refit;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public class RedmineClient
	{
		private readonly IRedmineApiClient _apiClient;
		public string ApiKey { get; }

		public RedmineClient(string baseUri, string apiKey, HttpMessageHandler httpMessageHandler)
		{
			_apiClient = RestService.For<IRedmineApiClient>(baseUri,
				new RefitSettings {HttpMessageHandlerFactory = () => httpMessageHandler});
			ApiKey = apiKey;
		}

		private class PaginatedEnumerator<T> : IAsyncEnumerator<T>
		{
			private Func<int, int, Task<IPaginated<T>>> _getPaginatedFunc;
			private int _offset;
			private int? _total;
			private readonly List<T> _tickets;
			private int _index;
			private int _limit;

			public PaginatedEnumerator(Func<int, int, Task<IPaginated<T>>> getPaginatedFunc, int offset, int limit)
			{
				_getPaginatedFunc = getPaginatedFunc;
				_offset = offset;
				_limit = limit;
				_tickets = new List<T>();
				_index = 0;
			}

			public async Task<bool> MoveNext()
			{
				if (_index < _tickets.Count)
				{
					Current = _tickets[_index++];
					return true;
				}

				if (!_total.HasValue || _offset < _total)
				{
					var response = await _getPaginatedFunc(_offset, _limit);

					_tickets.AddRange(response.Data);

					_offset += response.Data.Length;

					_total = (int)response.TotalCount;
					_limit = (int)response.Limit;

					Current = _tickets[_index++];
					return true;
				}

				return false;
			}

			public T Current { get; private set; }

			public void Dispose()
			{
				_index = 0;
				_getPaginatedFunc = null;
				_offset = 0;
			}
		}

		private class PaginatedEnumerable<T> : IAsyncEnumerable<T>
		{
			public const int DefaultLimit = 100;

			private readonly Func<int, int, Task<IPaginated<T>>> _getPaginatedFunc;
			private readonly int _offset;
			private readonly int _limit;

			public PaginatedEnumerable(Func<int, int, Task<IPaginated<T>>> getPaginatedFunc, int offset = 0, int limit = DefaultLimit)
			{
				_getPaginatedFunc = getPaginatedFunc;
				_offset = offset;
				_limit = limit;
			}

			public IAsyncEnumerator<T> GetEnumerator()
			{
				return new PaginatedEnumerator<T>(_getPaginatedFunc, _offset, _limit);
			}
		}

		public IAsyncEnumerable<Membership> EnumerateMembershipsAsync(int projectId)
		{
			async Task<IPaginated<Membership>> GetPaginated(int offset, int limit)
			{
				return await _apiClient.GetMembershipsAsync(ApiKey, projectId, offset, limit);
			}

			return new PaginatedEnumerable<Membership>(GetPaginated);
		}

		public IAsyncEnumerable<Ticket> EnumerateTicketsAsync(IdsFilter statusIds = null, IdsFilter trackerIds = null, 
			string subject = null, DateTime? updatedOnFrom = null, DateTime? updatedOnTo = null)
		{
			var subjectEncoded = HttpUtility.UrlEncode(subject);

			async Task<IPaginated<Ticket>> GetTicketsPaginated(int offset, int limit)
			{
				return await _apiClient.GetTicketsAsync(ApiKey, statusIds?.ToString(),
					trackerIds?.ToString(), subjectEncoded, updatedOnFrom, updatedOnTo, offset, limit);
			}

			return new PaginatedEnumerable<Ticket>(GetTicketsPaginated);
		}

		public Task CreateTicketAsync(TicketUpdate ticketUpdate)
		{
			var request = new TicketUpdateRequest {Data = ticketUpdate};
			return _apiClient.CreateTicketAsync(ApiKey, request);
		}

		public Task UpdateTicketAsync(TicketUpdate ticketUpdate)
		{
			var request = new TicketUpdateRequest { Data = ticketUpdate };
			return _apiClient.UpdateTicketAsync(ApiKey, request);
		}

		public Task DeleteTicketAsync(int ticketId)
		{
			return _apiClient.DeleteTicketAsync(ApiKey, id);
		}

		public Task<RelationsGetResponse> GetRelationsAsync(int ticketId)
		{

		}
	}
}