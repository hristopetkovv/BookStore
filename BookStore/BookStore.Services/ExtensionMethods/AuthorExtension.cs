using BookStore.Data.Data.Models;
using BookStore.Services.ViewModels.Authors.Enums;
using System.Linq;

namespace BookStore.Services.ExtensionMethods
{
    public static class AuthorExtension
    {
        public static IQueryable<Author> OrderAuthors(this IQueryable<Author> author, AuthorSortOrder sortOrder)
        {
            author = sortOrder switch
            {
                AuthorSortOrder.FirstName => author.OrderBy(a => a.FirstName),
                AuthorSortOrder.FirstNameDescending => author.OrderByDescending(a => a.FirstName),
                AuthorSortOrder.LastNameDescending => author.OrderByDescending(a => a.LastName),
                AuthorSortOrder.BooksCount => author.OrderByDescending(a => a.Books.Count()),
                AuthorSortOrder.LastName => author.OrderBy(a => a.LastName),
                _ => author.OrderBy(a => a.FirstName),
            };

            return author;
        }
    }
}
