using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class MembershipGetResponse : IRedmineResponse<Membership>
	{
		[JsonProperty("membership")]
		public Membership Data { get; set; }
	}
}