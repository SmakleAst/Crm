﻿using System.Linq.Expressions;

namespace Crm.Application.Common.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source,
            bool condition, Expression<Func<T, bool>> predicate)
        {
            if (condition)
            {
                return source.Where(predicate);
            }

            return source;
        }
    }
}
