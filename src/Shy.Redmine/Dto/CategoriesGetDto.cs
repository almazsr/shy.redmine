using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class CategoriesGetDto
    {
        [JsonProperty("issue_categories")]
        public IdName[] Categories { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
    }
}