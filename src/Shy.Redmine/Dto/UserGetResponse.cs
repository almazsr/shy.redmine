using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class UserGetResponse : IRedmineResponse<User>
    {
        [JsonProperty("user")]
        public User Data { get; set; }
    }
}