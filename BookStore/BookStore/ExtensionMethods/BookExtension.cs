using BookStore.Data.Data.Models;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Books.Enums;
using System.Linq;

namespace BookStore.ExtensionMethods
{
    public static class BookExtension
    {
        public static IQueryable<Book> OrderBooks(this IQueryable<Book> book, BookFilterRequestModel filter)
        {
            book = filter.SortOrder switch
            {
                BookSortOrder.Title => book.OrderBy(b => b.Title),
                BookSortOrder.PriceDescending => book.OrderByDescending(b => b.Price),
                BookSortOrder.Price => book.OrderBy(b => b.Price),
                BookSortOrder.TitleDescending => book.OrderByDescending(b => b.Title),
                _ => book.OrderBy(b => b.Title),
            };
            return book;
        }

        public static IQueryable<Book> SortBooks(this IQueryable<Book> book, BookFilterRequestModel filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchByTitle))
            {
                book = book.Where(b => b.Title.ToLower().Contains(filter.SearchByTitle.ToLower()));
            }

            if (filter.MinPrice.HasValue)
            {
                book = book.Where(b => b.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                book = book.Where(b => b.Price <= filter.MaxPrice.Value);
            }

            return book;
        }
    }
}
