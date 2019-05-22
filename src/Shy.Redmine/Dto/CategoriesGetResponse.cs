using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class CategoriesGetResponse
    {
        [JsonProperty("issue_categories")]
        public IdName[] Data { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
    }
}