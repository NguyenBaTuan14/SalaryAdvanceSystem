using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.DTOs;
using System.Linq.Expressions;

namespace SalaryAdvanceSource.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByDynamic<T>(
    this IQueryable<T> query, string propertyName, bool descending)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = descending ? "OrderByDescending" : "OrderBy";
            var result = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type)
                .Invoke(null, new object[] { query, lambda });

            return (IQueryable<T>)result!;
        }

        public static async Task<PagedResultDto<T>> ToPagedResultAsync<T>(
            this IQueryable<T> query,
            PagedRequestDto request,
            params Expression<Func<T, string>>[] searchSelectors) where T : class
        {
            if (!string.IsNullOrWhiteSpace(request.SearchTerm) && searchSelectors?.Any() == true)
            {
                Expression? orExpression = null;
                var parameter = Expression.Parameter(typeof(T), "x");

                foreach (var selector in searchSelectors)
                {
                    var body = Expression.Invoke(selector, parameter);

                    var likeMethod = typeof(DbFunctionsExtensions).GetMethod(
                        nameof(DbFunctionsExtensions.Like),
                        new[] { typeof(DbFunctions), typeof(string), typeof(string) });

                    var functions = Expression.Property(null, typeof(EF), nameof(EF.Functions));
                    var pattern = Expression.Constant($"%{request.SearchTerm}%");

                    //var likeCall = Expression.Call(likeMethod!, functions, body, pattern);
                    var likeCall = Expression.Call(
                        typeof(DbFunctionsExtensions),
                        nameof(DbFunctionsExtensions.Like),
                        Type.EmptyTypes,
                        Expression.Constant(EF.Functions),
                        Expression.Call(body, nameof(string.ToLower), Type.EmptyTypes),
                        Expression.Constant($"%{request.SearchTerm.ToLower()}%")
                    );

                    orExpression = orExpression == null
                        ? (Expression)likeCall
                        : Expression.OrElse(orExpression, likeCall);
                }

                if (orExpression != null)
                {
                    var lambda = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                    query = query.Where(lambda);
                }
            }

            if (!string.IsNullOrEmpty(request.SortField))
            {
                query = query.OrderByDynamic(request.SortField, request.SortDescending);
            }

            var total = await query.CountAsync();
            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResultDto<T>
            {
                Items = items,
                TotalCount = total
            };
        }

    }
}
