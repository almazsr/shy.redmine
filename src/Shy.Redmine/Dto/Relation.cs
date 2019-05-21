using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class Relation
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("issue_id")]
		public long IssueId { get; set; }

		[JsonProperty("issue_to_id")]
		public long IssueToId { get; set; }

		[JsonProperty("relation_type")]
		public string RelationType { get; set; }
	}
}