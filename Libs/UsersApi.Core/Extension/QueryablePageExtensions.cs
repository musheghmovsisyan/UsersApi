using UsersApi.Core.Contracts.Common;

namespace UsersApi.Core.Extension;

public static class QueryablePageExtensions
{
    public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int? pageNumber) where T : class
    {
        if (pageNumber is not > 0)
        {
            return query;
        }

        var skip = (pageNumber.Value - 1) * Defines.PageSize;
        return query.Skip(skip).Take(Defines.PageSize);
    }
}