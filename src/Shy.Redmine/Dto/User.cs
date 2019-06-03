using System;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("created_on", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RedmineDateTimeConverter))]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("last_login_on", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RedmineDateTimeConverter))]
        public DateTimeOffset LastLoginOn { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}