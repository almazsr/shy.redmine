namespace Shy.Redmine.Dto
{
	public interface IPaginated
	{
		long TotalCount { get; set; }

		long Offset { get; set; }

		long Limit { get; set; }
    }

    public interface IPaginated<T> : IPaginated
    {
        T[] Data { get; set; }
    }
}