using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public static class RedminePaginationHelper
	{
		public static async Task<IList<T>> GetAllAsync<T>(Func<int, int, Task<IRedminePaginatedResponse<T>>> getPaginatedFunc, int initialOffset = 0, int count = int.MaxValue)
		{
			var result = new List<T>();

			var totalCount = long.MaxValue;
			var offset = initialOffset;

			while(result.Count < Math.Min(count, totalCount - initialOffset))
			{
				var response = await getPaginatedFunc(offset, count);
				offset += response.Data.Length;
				result.AddRange(response.Data);
				totalCount = response.TotalCount;
			}

			return result;
		}
	}
}