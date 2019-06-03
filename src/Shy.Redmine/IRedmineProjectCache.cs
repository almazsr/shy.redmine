using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public interface IRedmineProjectCache
	{
	    RedmineConfiguration Configuration { get; }

	    Task ApplyConfigurationAsync(RedmineConfiguration configuration);
        Task RefreshAsync();
	    Task LoadAsync();

        TicketCategory[] Categories { get; }
		TicketType[] Types { get; }
		TicketPriority[] Priorities { get; }
		TicketStatus[] Statuses { get; }
		Version[] Versions { get; }
		Membership[] Memberships { get; }
	}
}