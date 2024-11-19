using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.QueryExtensions
{
	public static class QueryableExtensions
	{
		public static IQueryable<T> AddTracking<T>(this IQueryable<T> query, bool withTracking) 
			where T : class
		{
			return withTracking ? query : query.AsNoTracking();
		}
	}
}
