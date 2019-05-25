using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationGetResponse
	{
		[JsonProperty("relation")]
		public Relation Relation { get; set; }
	}
}