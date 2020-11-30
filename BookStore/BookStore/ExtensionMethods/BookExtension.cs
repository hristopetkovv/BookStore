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
            switch (model.SortOrder)
            {
                case BookSortOrder.PriceDescending:
                    book = book.OrderByDescending(b => b.Price);
                    break;
                case BookSortOrder.Price:
                    book = book.OrderBy(b => b.Price);
                    break;
                case BookSortOrder.TitleDescending:
                    book = book.OrderByDescending(b => b.Title);
                    break;
                default:
                    book = book.OrderBy(b => b.Title);
                    break;
            }

            return book;
        }
    }
}
