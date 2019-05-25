using System;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class Project
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("status")]
		public long Status { get; set; }

		[JsonProperty("created_on", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(RedmineDateTimeConverter))]
		public DateTimeOffset CreatedOn { get; set; }

		[JsonProperty("updated_on", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(RedmineDateTimeConverter))]
		public DateTimeOffset UpdatedOn { get; set; }
	}
}