﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Dynamic_Events_API.Commons
{
    public static class ExtNetGridHelper
    {
        public static object ToGrid<T>(this IQueryable<T> query, int page, int start, int limit, string sort)
        {

            foreach (var item in JsonConvert.DeserializeObject<List<Sorter>>(sort))
            {
                query = query.OrderBy<T>(item.property, item.direction);
            }

            var data = query.Skip(start).Take(limit).ToList();
            var total = query.Count();
            return new { data, total };
        }
    }

    public class Sorter
    {
        public string property { get; set; }
        public string direction { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    public static class LinqExtensions
    {
        /// <summary>
        /// Orders the sequence by specific column and direction.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <param name="direction">If set to "asc" then ascending otherwise descending.</param>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction)
        {
            string methodName = string.Format("OrderBy{0}", direction.ToLower() == "asc" ? "" : "descending");
            ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
            MemberExpression memberAccess = null;
            //
            foreach (var property in sortColumn.Split('.'))
            {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }
            //
            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parameter);
            MethodCallExpression result = Expression.Call(
                      typeof(Queryable),
                      methodName,
                      new[] { query.ElementType, memberAccess.Type },
                      query.Expression,
                      Expression.Quote(orderByLambda));
            //
            return query.Provider.CreateQuery<T>(result);
        }
    }


}