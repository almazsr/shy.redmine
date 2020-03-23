using System;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketUpdate
	{
		[JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
		public string Subject { get; set; }

		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(RedmineDateTimeConverter))]
		public DateTimeOffset? DueDate { get; set; }

		[JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(RedmineDateTimeConverter))]
		public DateTimeOffset? StartDate { get; set; }

		[JsonProperty("done_ratio", NullValueHandling = NullValueHandling.Ignore)]
		public long? DoneRatio { get; set; }

		[JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
		public CustomField[] CustomFields { get; set; }

		[JsonProperty("status_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? StatusId { get; set; }
		[JsonProperty("priority_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? PriorityId { get; set; }
		[JsonProperty("tracker_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? TrackerId { get; set; }
		[JsonProperty("assigned_to_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? AssignedToId { get; set; }
		[JsonProperty("parent_issue_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? ParentId { get; set; }
		[JsonProperty("category_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? CategoryId { get; set; }
	    [JsonProperty("fixed_version_id", NullValueHandling = NullValueHandling.Ignore)]
	    public long? FixedVersionId { get; set; }
	    [JsonProperty("project_id", NullValueHandling = NullValueHandling.Ignore)]
	    public long? ProjectId { get; set; }
	}
}