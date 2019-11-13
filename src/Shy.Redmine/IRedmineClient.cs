using System;
using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
    public interface IRedmineClient
    {
        Task AddTicketWatcherAsync(long ticketId, WatcherAddRequest request);
        Task CreateProjectAsync(ProjectUpdateRequest request);
        Task CreateProjectMembershipAsync(long projectId, MembershipCreateRequest request);
        Task AddTicketRelationAsync(long ticketId, RelationCreateRequest request);
        Task CreateTicketAsync(TicketUpdateRequest request);
        Task DeleteMembershipAsync(long id);
        Task DeleteProjectAsync(long id);
        Task DeleteRelationAsync(long id);
        Task DeleteTicketAsync(long id);
        Task<MembershipGetResponse> GetMembershipAsync(long id);
        Task<ProjectGetResponse> GetProjectAsync(long id);
        Task<MembershipsGetPaginatedResponse> GetProjectMembershipsAsync(long projectId, int? offset = null, int? limit = null);
        Task<ProjectsGetPaginatedResponse> GetProjectsAsync(int? offset = null, int? limit = null);
        Task<VersionsGetResponse> GetProjectVersionsAsync(long projectId);
        Task<RelationGetResponse> GetRelationAsync(long id);
        Task<TicketGetResponse> GetTicketAsync(long id, string[] include = null);
        Task<TicketCategoriesGetResponse> GetTicketCategoriesAsync(long projectId);
        Task<TicketPrioritiesGetResponse> GetTicketPrioritiesAsync();
        Task<RelationsGetResponse> GetTicketRelationsAsync(long ticketId);
        Task<TicketsGetPaginatedResponse> GetTicketsAsync(long[] ids = null, long[] statusIds = null, long[] trackerIds = null, long[] assignedToIds = null, string subject = null, DateTime? updatedOnFrom = null, DateTime? updatedOnTo = null, string[] include = null, int? offset = null, int? limit = null);
        Task<TicketStatusesGetResponse> GetTicketStatusesAsync();
        Task<TicketTypesGetResponse> GetTicketTypesAsync();
        Task<UserGetResponse> GetUserAsync(long id);
        Task RemoveTicketWatcherAsync(long ticketId, long watcherId);
        Task UpdateMembershipAsync(long id, MembershipUpdateRequest request);
        Task UpdateProjectAsync(long id, ProjectUpdateRequest request);
        Task UpdateTicketAsync(long id, TicketUpdateRequest request);
    }
}