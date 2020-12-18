using BookStore.Data.Models;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Books.Enums;
using System.Linq;

namespace BookStore.ExtensionMethods
{
    public static class BookExtension
    {
        public static IQueryable<Book> OrderBooks(this IQueryable<Book> book, BookFilterRequestModel model)
        {
            book = model.SortOrder switch
            {
                BookSortOrder.Title => book.OrderBy(b => b.Title),
                BookSortOrder.PriceDescending => book.OrderByDescending(b => b.Price),
                BookSortOrder.Price => book.OrderBy(b => b.Price),
                BookSortOrder.TitleDescending => book.OrderByDescending(b => b.Title),
                _ => book.OrderBy(b => b.Title),
            };
            return book;
        }

        public static IQueryable<Book> SortBooks(this IQueryable<Book> book, BookFilterRequestModel model)
        {
            if (!string.IsNullOrEmpty(model.SearchByTitle))
            {
                return book.Where(b => b.Title.Contains(model.SearchByTitle));
            }

            return book;
        }
    }
}
