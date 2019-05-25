using System;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketUpdate
	{
		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(RedmineDateTimeConverter))]
		public DateTimeOffset? DueDate { get; set; }

		[JsonProperty("done_ratio")]
		public long? DoneRatio { get; set; }

		[JsonProperty("custom_fields")]
		public CustomField[] CustomFields { get; set; }

		[JsonProperty("status_id")]
		public long? StatusId { get; set; }
		[JsonProperty("priority_id")]
		public long? PriorityId { get; set; }
		[JsonProperty("tracker_id")]
		public long? TrackerId { get; set; }
		[JsonProperty("assigned_to_id")]
		public long? AssignedToId { get; set; }
		[JsonProperty("parent_issue_id")]
		public long? ParentId { get; set; }
		[JsonProperty("category_id")]
		public long? CategoryId { get; set; }
	    [JsonProperty("fixed_version_id")]
	    public long? FixedVersionId { get; set; }
	    [JsonProperty("project_id")]
	    public long? ProjectId { get; set; }
	}
}