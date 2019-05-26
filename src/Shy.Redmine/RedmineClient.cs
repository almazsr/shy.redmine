using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Refit;
using Shy.Redmine.Dto;
using Version = Shy.Redmine.Dto.Version;

namespace Shy.Redmine
{
	public class RedmineClient
	{
		private readonly IRedmineApiClient _apiClient;
		public string ApiKey { get; }

		public RedmineClient(Uri baseUri, string apiKey, HttpMessageHandler httpMessageHandler)
		{
			var httpClient = new HttpClient(httpMessageHandler)
			{
				BaseAddress = baseUri
			};
			_apiClient = RestService.For<IRedmineApiClient>(httpClient);
			ApiKey = apiKey;
		}

		public RedmineClient(Uri baseUri, string apiKey) : this (baseUri, apiKey, new HttpClientHandler())
		{
		}

		public RedmineClient(string baseUri, string apiKey) : this(new Uri(baseUri), apiKey)
		{
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
				async (o, l) => await _apiClient.GetProjectMembershipsAsync(ApiKey, projectId, o, l), offset,
				count);
		}

		public Task<IList<Ticket>> GetAllTicketsAsync(IdsFilter statusIds = null, IdsFilter trackerIds = null, 
			string subject = null, DateTime? updatedOnFrom = null, DateTime? updatedOnTo = null, IncludeFilter includeFilter = null, int offset = 0, int count = int.MaxValue)
		{
			var subjectEncoded = HttpUtility.UrlEncode(subject);

			return GetPaginatedAllAsync<Ticket>(
				async (o, l) => await _apiClient.GetTicketsAsync(ApiKey, statusIds?.ToString(),
					trackerIds?.ToString(), subjectEncoded, updatedOnFrom, updatedOnTo, includeFilter?.ToString(), o, l), offset,
				count);
		}

		public async Task<Ticket> GetTicketAsync(int id, IncludeFilter includeFilter = null)
		{
			var response = await _apiClient.GetTicketAsync(ApiKey, id, includeFilter?.ToString());
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

		public Task<IList<Project>> GetAllProjectsAsync(int offset = 0, int count = int.MaxValue)
		{
			return GetPaginatedAllAsync<Project>(async (o, l) => await _apiClient.GetProjectsAsync(ApiKey, o, l), offset,
				count);
		}

		public async Task<Project> GetProjectAsync(int id)
		{
			var response = await _apiClient.GetProjectAsync(ApiKey, id);
			return response.Data;
		}

		public Task CreateProjectAsync(ProjectUpdateRequest request)
		{
			return _apiClient.CreateProjectAsync(ApiKey, request);
		}

		public Task DeleteProjectAsync(int id)
		{
			return _apiClient.DeleteProjectAsync(ApiKey, id);
		}

		public Task UpdateProjectAsync(ProjectUpdateRequest request)
		{
			return _apiClient.UpdateProjectAsync(ApiKey, request);
		}

		public async Task<Membership> GetMembershipAsync(int id)
		{
			var response = await _apiClient.GetMembershipAsync(ApiKey, id);
			return response.Data;
		}

		public Task CreateProjectMembershipAsync(int projectId, MembershipCreateRequest request)
		{
			return _apiClient.CreateProjectMembershipAsync(ApiKey, projectId, request);
		}

		public Task UpdateMembershipAsync(int id, MembershipUpdateRequest request)
		{
			return _apiClient.UpdateMembershipAsync(ApiKey, id, request);
		}

		public Task DeleteMembershipAsync(int id)
		{
			return _apiClient.DeleteMembershipAsync(ApiKey, id);
		}

		public async Task<IdName[]> GetTicketCategoriesAsync(int projectId)
		{
			var response = await _apiClient.GetTicketCategoriesAsync(ApiKey, projectId);
			return response.Data;
		}

		public async Task<TicketType[]> GetTicketTypesAsync()
		{
			var response = await _apiClient.GetTicketTypesAsync(ApiKey);
			return response.Data;
		}

		public async Task<TicketPriority[]> GetTicketPriorirties(int projectId)
		{
			var response = await _apiClient.GetTicketPrioritiesAsync(ApiKey, projectId);
			return response.Data;
		}

		public Task AddTicketWatcherAsync(int ticketId, WatcherAddRequest request)
		{
			return _apiClient.AddTicketWatcherAsync(ApiKey, ticketId, request);
		}

		public Task RemoveTicketWatcherAsync(int ticketId, int watcherId)
		{
			return _apiClient.RemoveTicketWatcherAsync(ApiKey, ticketId, watcherId);
		}

		public async Task<TicketStatus[]> GetTicketStatusesAsync()
		{
			var response = await _apiClient.GetTicketStatusesAsync(ApiKey);
			return response.Data;
		}

		public async Task<Version[]> GetProjectVersionsAsync(int projectId)
		{
			var response = await _apiClient.GetProjectVersionsAsync(ApiKey, projectId);
			return response.Data;
		}
	}
}