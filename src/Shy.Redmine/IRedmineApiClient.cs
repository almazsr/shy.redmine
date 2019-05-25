using System;
using System.Threading.Tasks;
using Refit;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public interface IRedmineApiClient
	{
		[Get("/issues.json")]
		Task<TicketsGetPaginatedResponse> GetTicketsAsync(string key, [AliasAs("status_id")] string statusIds = null,
			[AliasAs("tracker_id")] string trackerIds = null, [Query(Format = "~{0}")] string subject = null, [AliasAs("updated_on"), Query(Format = ">={0:yyyy-MM-dd}")] DateTime? updatedOnFrom = null, 
			[AliasAs("updated_on"), Query(Format = "<={0:yyyy-MM-dd}")] DateTime? updatedOnTo = null, int? offset = null, int? limit = null);

		[Get("/issues/{id}.json")]
		Task<TicketGetResponse> GetTicketAsync(string key, int id, string include = null);

		[Post("/issues.json")]
		Task CreateTicketAsync(string key, [Body] TicketUpdateRequest request);

		[Post("/issues/{ticketId}/watchers.json")]
		Task AddTicketWatcherAsync(string key, int ticketId, [Body] WatcherAddRequest request);

		[Delete("/issues/{ticketId}/watchers/{watcherId}.json")]
		Task RemoveTicketWatcherAsync(string key, int ticketId, int watcherId);

		[Put("/issues.json")]
		Task UpdateTicketAsync(string key, [Body] TicketUpdateRequest request);

		[Delete("/issues/{id}.json")]
		Task DeleteTicketAsync(string key, int id);

		[Get("/issues/{ticketId}/relations.json")]
		Task<RelationsGetResponse> GetTicketRelationsAsync(string key, int ticketId);

		[Get("/relations/{id}.json")]
		Task<RelationGetResponse> GetRelationAsync(string key, int id);

		[Post("/relations.json")]
		Task CreateRelationAsync(string key, RelationCreateRequest request);

		[Delete("/relations/{id}.json")]
		Task DeleteRelation(string key, int id);

		[Get("/projects/{projectId}/memberships.json")]
		Task<MembershipsGetPaginatedResponse> GetMembershipsAsync(string key, int projectId, int? offset = null, int? limit = null);
	}
}
