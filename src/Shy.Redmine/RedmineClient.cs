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

		private async Task<IList<T>> GetPaginatedAllAsync<T>(Func<int, int, Task<IPaginated<T>>> getPaginatedFunc, int initialOffset = 0, int count = int.MaxValue)
		{
			var result = new List<T>();

			var totalCount = long.MaxValue;
			var offset = initialOffset;

			while (result.Count < Math.Min(count, totalCount - initialOffset))
			{
				var response = await getPaginatedFunc(offset, count);
				offset += response.Data.Length;
				result.AddRange(response.Data);
				totalCount = response.TotalCount;
			}

			return result;
		}

		public Task<IList<Membership>> GetAllMembershipsAsync(int projectId, int offset = 0,
			int count = int.MaxValue)
		{
			return GetPaginatedAllAsync<Membership>(
				async (o, l) => await _apiClient.GetMembershipsAsync(ApiKey, projectId, o, l), offset,
				count);
		}

		public Task<IList<Ticket>> GetAllTicketsAsync(IdsFilter statusIds = null, IdsFilter trackerIds = null, 
			string subject = null, DateTime? updatedOnFrom = null, DateTime? updatedOnTo = null, int offset = 0, int count = int.MaxValue)
		{
			var subjectEncoded = HttpUtility.UrlEncode(subject);

			return GetPaginatedAllAsync<Ticket>(
				async (o, l) => await _apiClient.GetTicketsAsync(ApiKey, statusIds?.ToString(),
					trackerIds?.ToString(), subjectEncoded, updatedOnFrom, updatedOnTo, o, l), offset,
				count);
		}

		public async Task<Ticket> GetTicketAsync(int id)
		{
			var response = await _apiClient.GetTicketAsync(ApiKey, id);
			return response.Data;
		}

		public Task CreateTicketAsync(TicketUpdate ticket)
		{
			var request = new TicketUpdateRequest {Data = ticket};
			return _apiClient.CreateTicketAsync(ApiKey, request);
		}

		public Task UpdateTicketAsync(TicketUpdate ticket)
		{
			var request = new TicketUpdateRequest { Data = ticket };
			return _apiClient.UpdateTicketAsync(ApiKey, request);
		}

		public Task DeleteTicketAsync(int ticketId)
		{
			return _apiClient.DeleteTicketAsync(ApiKey, ticketId);
		}

		public async Task<Relation[]> GetTicketRelationsAsync(int ticketId)
		{
			var response = await _apiClient.GetTicketRelationsAsync(ApiKey, ticketId);
			return response.Relations;
		}

		public Task CreateRelationAsync(RelationCreate relation)
		{
			var request = new RelationCreateRequest {Data = relation};
			return _apiClient.CreateRelationAsync(ApiKey, request);
		}

		public Task DeleteRelationAsync(int id)
		{
			return _apiClient.DeleteRelationAsync(ApiKey, id);
		}

		public async Task<Relation> GetRelationAsync(int id)
		{
			var response = await _apiClient.GetRelationAsync(ApiKey, id);
			return response.Data;
		}

		public async Task<Project[]> GetProjectsAsync()
		{
			var response = await _apiClient.GetProjectsAsync(ApiKey);
			return response.Data;
		}
	}
}