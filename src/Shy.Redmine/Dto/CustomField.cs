using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class CustomField
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}