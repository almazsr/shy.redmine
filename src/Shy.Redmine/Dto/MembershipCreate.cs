using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class MembershipCreate
	{
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("role_ids")]
		public long[] RoleIds { get; set; }
	}
}