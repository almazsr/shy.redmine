using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketGet
	{
		[JsonProperty("id")]
		public long Id { get; set; }

	    [JsonProperty("journals")]
	    public Journal[] Journals { get; set; }

        [JsonProperty("project")]
		public IdName Project { get; set; }

		[JsonProperty("tracker")]
		public IdName Tracker { get; set; }

		[JsonProperty("status")]
		public IdName Status { get; set; }

		[JsonProperty("priority")]
		public IdName Priority { get; set; }

		[JsonProperty("author")]
		public IdName Author { get; set; }

		[JsonProperty("assigned_to")]
		public IdName AssignedTo { get; set; }

		[JsonProperty("category")]
		public IdName Category { get; set; }

		[JsonProperty("fixed_version")]
		public IdName FixedVersion { get; set; }

		[JsonProperty("parent")]
		public ParentTicket Parent { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("due_date")]
		public DateTimeOffset DueDate { get; set; }

		[JsonProperty("done_ratio")]
		public long DoneRatio { get; set; }

		[JsonProperty("custom_fields")]
		public CustomField[] CustomFields { get; set; }

        [JsonProperty("created_on")]
		public DateTimeOffset CreatedOn { get; set; }

		[JsonProperty("updated_on")]
		public DateTimeOffset UpdatedOn { get; set; }

		[JsonProperty("children")]
		public ChildTicket[] Children { get; set; }
	}
}