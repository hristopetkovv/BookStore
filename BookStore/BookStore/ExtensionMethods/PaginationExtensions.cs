using BookStore.ViewModels.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ExtensionMethods
{
    public static class PaginationExtensions
    {
        public static async Task<SearchResultDto<T>> WithPaginationAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
            where T : class
        {
            int count = await query.CountAsync();

            var result = new SearchResultDto<T>
            {
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Result = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()
            };

            return result;
        }
    }
}
