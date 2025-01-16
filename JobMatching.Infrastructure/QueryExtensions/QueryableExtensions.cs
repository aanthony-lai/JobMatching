using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.QueryExtensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AddTracking<T>(this IQueryable<T> query, bool withTracking)
            where T : EntityBase
        {
            return withTracking ? query : query.AsNoTracking();
        }
    }
}
