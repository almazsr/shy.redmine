using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketsGetPaginatedResponse : IPaginated<Ticket>
	{
		[JsonProperty("issues")]
		public Ticket[] Data { get; set; }

		[JsonProperty("total_count")]
		public long TotalCount { get; set; }

		[JsonProperty("offset")]
		public long Offset { get; set; }

		[JsonProperty("limit")]
		public long Limit { get; set; }
	}
}