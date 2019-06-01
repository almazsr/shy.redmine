using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class TicketCategoriesGetResponse : IRedmineResponse<TicketCategory[]>
    {
        [JsonProperty("issue_categories")]
        public TicketCategory[] Data { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
	}
}