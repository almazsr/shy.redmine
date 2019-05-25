using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class MembershipCreateRequest
	{
		[JsonProperty("membership")]
		public MembershipCreate Data { get; set; }
	}
}