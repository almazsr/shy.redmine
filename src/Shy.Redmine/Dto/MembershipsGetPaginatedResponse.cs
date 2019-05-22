using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class MembershipsGetPaginatedResponse : IPaginated<Membership>
	{
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

		[JsonProperty("memberships")]
		public Membership[] Data { get; set; }
	}
}