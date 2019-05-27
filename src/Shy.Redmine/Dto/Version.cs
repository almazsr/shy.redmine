using System;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class Version
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("project")]
        public IdName Project { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RedmineDateTimeConverter))]
        public DateTimeOffset DueDate { get; set; }

        [JsonProperty("sharing")]
        public string Sharing { get; set; }

        [JsonProperty("created_on", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RedmineDateTimeConverter))]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("updated_on", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RedmineDateTimeConverter))]
        public DateTimeOffset UpdatedOn { get; set; }
    }
}