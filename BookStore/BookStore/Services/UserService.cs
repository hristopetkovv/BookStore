using BookStore.Data;
using BookStore.ViewModels.Home;
using System.Linq;

namespace BookStore.Services
{
    public class UserService : IUserService
    {
        private readonly BookStoreDbContext dbContext;

        public UserService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CartListingResponseModel ShowCart(int userId)
        {
            var books = this.dbContext
                 .UserBook
                 .Where(u => u.UserId == userId)
                 .Select(u => new CartViewModel
                 {
                     Pieces = u.Pieces,
                     BookId = u.BookId,
                     TotalPrice = u.Book.Price * u.Pieces,
                     PriceForEach = u.Book.Price,
                     ImageUrl = u.Book.ImageUrl,
                     Title = u.Book.Title,
                     AuthorName = u.Book.Authors.Select(a => a.Author.Fullname)
                 }).ToList();

            var userBooks = new CartListingResponseModel 
            { 
                books = books,
                TotalPrice = books.Select(x => x.TotalPrice).Sum()
            };

            return userBooks;
        }
    }
}
