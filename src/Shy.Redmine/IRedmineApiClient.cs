using System;
using System.Threading.Tasks;
using Refit;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public interface IRedmineApiClient
	{
		[Get("/issues.json")]
		Task<TicketsGetPaginatedResponse> GetTicketsAsync([AliasAs("status_id"), Query(CollectionFormat.Pipes)] long[] statusIds = null,
			[AliasAs("tracker_id"), Query(CollectionFormat.Pipes)] long[] trackerIds = null, [Query(Format = "~{0}")] string subject = null, 
			[AliasAs("updated_on"), Query(Format = ">={0:yyyy-MM-dd}")] DateTime? updatedOnFrom = null, 
			[AliasAs("updated_on"), Query(Format = "<={0:yyyy-MM-dd}")] DateTime? updatedOnTo = null, 
		    [Query(CollectionFormat.Csv)] string[] include = null, int? offset = null, int? limit = null);
		[Get("/issues/{id}.json")]
		Task<TicketGetResponse> GetTicketAsync(int id, [Query(",")] string[] include = null);
		[Post("/issues.json")]
		Task CreateTicketAsync([Body] TicketUpdateRequest request);
		[Put("/issues.json")]
		Task UpdateTicketAsync([Body] TicketUpdateRequest request);
		[Delete("/issues/{id}.json")]
		Task DeleteTicketAsync(int id);

		[Post("/issues/{ticketId}/watchers.json")]
		Task AddTicketWatcherAsync(int ticketId, [Body] WatcherAddRequest request);
		[Delete("/issues/{ticketId}/watchers/{watcherId}.json")]
		Task RemoveTicketWatcherAsync(int ticketId, int watcherId);

		[Get("/issues/{ticketId}/relations.json")]
		Task<RelationsGetResponse> GetTicketRelationsAsync(int ticketId);
		[Get("/relations/{id}.json")]
		Task<RelationGetResponse> GetRelationAsync(int id);
		[Post("/relations.json")]
		Task CreateRelationAsync(RelationCreateRequest request);
		[Delete("/relations/{id}.json")]
		Task DeleteRelationAsync(int id);

		[Get("/projects.json")]
		Task<ProjectsGetPaginatedResponse> GetProjectsAsync(int? offset = null, int? limit = null);
		[Get("/projects/{id}.json")]
		Task<ProjectGetResponse> GetProjectAsync(int id);
		[Post("/projects.json")]
		Task CreateProjectAsync([Body] ProjectUpdateRequest request);
		[Put("/projects.json")]
		Task UpdateProjectAsync([Body] ProjectUpdateRequest request);
		[Delete("/projects/{id}.json")]
		Task DeleteProjectAsync(int id);

		[Get("/projects/{projectId}/memberships.json")]
		Task<MembershipsGetPaginatedResponse> GetProjectMembershipsAsync(int projectId, int? offset = null, int? limit = null);
		[Get("/memberships/{id}.json")]
		Task<MembershipGetResponse> GetMembershipAsync(int id);
		[Post("/projects/{projectId}/memberships.json")]
		Task CreateProjectMembershipAsync(int projectId, [Body] MembershipCreateRequest request);
		[Put("/memberships/{id}.json")]
		Task UpdateMembershipAsync(int id, [Body] MembershipUpdateRequest request);
		[Delete("/memberships/{id}.json")]
		Task DeleteMembershipAsync(int id);

		[Get("/issue_statuses.json")]
		Task<TicketStatusesGetResponse> GetTicketStatusesAsync();

		[Get("/trackers.json")]
		Task<TicketTypesGetResponse> GetTicketTypesAsync();

		[Get("/projects/{projectId}/issue_categories.json")]
		Task<TicketCategoriesGetResponse> GetTicketCategoriesAsync(int projectId);

		[Get("/enumerations/issue_priorities.json")]
		Task<TicketPrioritiesGetResponse> GetTicketPrioritiesAsync(int projectId);

		[Get("/projects/{projectId}/versions.json")]
		Task<VersionsGetResponse> GetProjectVersionsAsync(int projectId);
	}
}
