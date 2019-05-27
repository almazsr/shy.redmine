using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationGetResponse : IRedmineResponse<Relation>
	{
		[JsonProperty("relation")]
		public Relation Data { get; set; }
	}
}