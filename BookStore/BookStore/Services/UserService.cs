using BookStore.Data;
using BookStore.ViewModels.Home;
using System.Collections.Generic;
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

        public IEnumerable<CartResponseModel> ShowCart(int userId)
        {
            var users = this.dbContext
                 .UserBook
                 .Where(u => u.UserId == userId)
                 .Select(u => new CartResponseModel
                 {
                     Pieces = u.Pieces,
                     BookId = u.BookId,
                     Price = u.Book.Price,
                     ImageUrl = u.Book.ImageUrl,
                     Title = u.Book.Title,
                     AuthorName = u.Book.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName)
                 }).ToList();

            return users;
        }
    }
}
