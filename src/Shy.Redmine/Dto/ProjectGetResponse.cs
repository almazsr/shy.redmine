using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class ProjectGetResponse
    {
        [JsonProperty("project")]
        public Project Data { get; set; }
    }
}