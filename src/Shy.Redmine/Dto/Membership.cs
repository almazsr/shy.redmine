using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class Membership
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("project")]
        public IdName Project { get; set; }

        [JsonProperty("user")]
        public IdName User { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }
    }
}