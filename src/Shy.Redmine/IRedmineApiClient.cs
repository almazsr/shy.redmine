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
			[AliasAs("tracker_id")] string trackerIds = null, [Query(Format = "~{0}")] string subject = null, 
			[AliasAs("updated_on"), Query(Format = ">={0:yyyy-MM-dd}")] DateTime? updatedOnFrom = null, 
			[AliasAs("updated_on"), Query(Format = "<={0:yyyy-MM-dd}")] DateTime? updatedOnTo = null, 
			string include = null, int? offset = null, int? limit = null);
		[Get("/issues/{id}.json")]
		Task<TicketGetResponse> GetTicketAsync(string key, int id, string include = null);
		[Post("/issues.json")]
		Task CreateTicketAsync(string key, [Body] TicketUpdateRequest request);
		[Put("/issues.json")]
		Task UpdateTicketAsync(string key, [Body] TicketUpdateRequest request);
		[Delete("/issues/{id}.json")]
		Task DeleteTicketAsync(string key, int id);

		[Post("/issues/{ticketId}/watchers.json")]
		Task AddTicketWatcherAsync(string key, int ticketId, [Body] WatcherAddRequest request);
		[Delete("/issues/{ticketId}/watchers/{watcherId}.json")]
		Task RemoveTicketWatcherAsync(string key, int ticketId, int watcherId);

		[Get("/issues/{ticketId}/relations.json")]
		Task<RelationsGetResponse> GetTicketRelationsAsync(string key, int ticketId);
		[Get("/relations/{id}.json")]
		Task<RelationGetResponse> GetRelationAsync(string key, int id);
		[Post("/relations.json")]
		Task CreateRelationAsync(string key, RelationCreateRequest request);
		[Delete("/relations/{id}.json")]
		Task DeleteRelationAsync(string key, int id);

		[Get("/projects.json")]
		Task<ProjectsGetPaginatedResponse> GetProjectsAsync(string key, int? offset = null, int? limit = null);
		[Get("/projects/{id}.json")]
		Task<ProjectGetResponse> GetProjectAsync(string key, int id);
		[Post("/projects.json")]
		Task CreateProjectAsync(string key, [Body] ProjectUpdateRequest request);
		[Put("/projects.json")]
		Task UpdateProjectAsync(string key, [Body] ProjectUpdateRequest request);
		[Delete("/projects/{id}.json")]
		Task DeleteProjectAsync(string key, int id);

		[Get("/projects/{projectId}/memberships.json")]
		Task<MembershipsGetPaginatedResponse> GetProjectMembershipsAsync(string key, int projectId, int? offset = null, int? limit = null);
		[Get("/memberships/{id}.json")]
		Task<MembershipGetResponse> GetMembershipAsync(string key, int id);
		[Post("/projects/{projectId}/memberships.json")]
		Task CreateProjectMembershipAsync(string key, int projectId, [Body] MembershipCreateRequest request);
		[Put("/memberships/{id}.json")]
		Task UpdateMembershipAsync(string key, int id, [Body] MembershipUpdateRequest request);
		[Delete("/memberships/{id}.json")]
		Task DeleteMembershipAsync(string key, int id);

		[Get("/issue_statuses.json")]
		Task<TicketStatusesGetResponse> GetTicketStatusesAsync(string key);

		[Get("/trackers.json")]
		Task<TicketTypesGetResponse> GetTicketTypesAsync(string key);

		[Get("/projects/{projectId}/issue_categories.json")]
		Task<TicketCategoriesGetResponse> GetTicketCategoriesAsync(string key, int projectId);

		[Get("/enumerations/issue_priorities.json")]
		Task<TicketPrioritiesGetResponse> GetTicketPrioritiesAsync(string key, int projectId);

		[Get("/projects/{projectId}/versions.json")]
		Task<VersionsGetResponse> GetProjectVersionsAsync(string key, int projectId);
	}
}
