using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class MembershipUpdateRequest
	{
		[JsonProperty("membership")]
		public MembershipUpdate Data { get; set; }
	}
}