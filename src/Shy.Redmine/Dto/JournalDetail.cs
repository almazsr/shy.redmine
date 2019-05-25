using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class JournalDetail
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("old_value")]
        public string OldValue { get; set; }

        [JsonProperty("new_value")]
        public string NewValue { get; set; }
    }
}