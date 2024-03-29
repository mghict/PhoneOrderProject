﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }


        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static async Task<IEnumerable<TSource>> ToPagedAsync<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            var result =
                await Task.Run(() =>
                {
                    return source.Skip((page - 1) * pageSize).Take(pageSize);
                });

            return result;
        }
    }
}
