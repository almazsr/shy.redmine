using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class ParentTicket
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}