namespace Shy.Redmine.Dto
{
	public interface IRedminePaginated
	{
		long TotalCount { get; set; }

		long Offset { get; set; }

		long Limit { get; set; }
    }
}