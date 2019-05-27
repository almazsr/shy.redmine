using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class TicketCategoriesGetResponse : IRedmineResponse<IdName[]>
    {
        [JsonProperty("issue_categories")]
        public IdName[] Data { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
	}
}