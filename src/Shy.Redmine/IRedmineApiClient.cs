using System;
using Refit;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public interface IRedmineApiClient
	{
		[Get("issues.json")]
		TicketsGetPaginatedDto GetTickets(string key, [AliasAs("status_id")] string statusIds = null,
			[AliasAs("tracker_id")] string trackerIds = null,  [AliasAs("updated_on"), Query(Format = ">={0:yyyy-MM-dd}")] DateTime? updatedAtFrom = null, 
			[AliasAs("updated_on"), Query(Format = "<={0:yyyy-MM-dd}")] DateTime? updatedAtTo = null, int? offset = null, int? limit = 0);
	}
}
