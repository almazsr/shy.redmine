using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class ProjectsGetPaginatedResponse : IRedminePaginatedResponse<Project>
	{
		[JsonProperty("projects")]
		public Project[] Data { get; set; }

		[JsonProperty("total_count")]
		public long TotalCount { get; set; }

		[JsonProperty("offset")]
		public long Offset { get; set; }

		[JsonProperty("limit")]
		public long Limit { get; set; }
	}
}