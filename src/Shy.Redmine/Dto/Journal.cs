using System;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class Journal
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user")]
        public IdName User { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("details")]
        public Detail[] Details { get; set; }
    }
}