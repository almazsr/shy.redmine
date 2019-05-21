using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class CustomField : IdName
    {
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}