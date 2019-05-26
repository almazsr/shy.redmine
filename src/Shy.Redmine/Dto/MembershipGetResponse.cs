using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class MembershipGetResponse
	{
		[JsonProperty("membership")]
		public Membership Data { get; set; }
	}
}