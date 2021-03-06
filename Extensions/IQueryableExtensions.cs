using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vega.Core.Models;

namespace Vega.Extensions
{
    public static class IQueryableExtensions
    {
        // public static IQueryable<Pojazd> ApplyOrdering(this IQueryable<Pojazd> query, PojazdQuery queryObj, Dictionary<string, Expression<Func<Pojazd, object>>> columnsMap)
        // {
        //     if (queryObj.IsSortAscending)            
        //         return query = query.OrderBy(columnsMap[queryObj.Sortby]);
        //     else
        //         return query = query.OrderByDescending(columnsMap[queryObj.Sortby]);
        // }        
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if(String.IsNullOrWhiteSpace(queryObj.Sortby) || !columnsMap.ContainsKey(queryObj.Sortby))
             return query;

            if (queryObj.IsSortAscending)            
                return query = query.OrderBy(columnsMap[queryObj.Sortby]);
            else
                return query = query.OrderByDescending(columnsMap[queryObj.Sortby]);
        }        
        
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;                
            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query = query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}