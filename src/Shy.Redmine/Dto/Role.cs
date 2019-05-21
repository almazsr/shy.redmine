using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class Role
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inherited", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Inherited { get; set; }
    }
}