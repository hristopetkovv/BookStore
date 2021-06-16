using BookStore.Data.Data;
using BookStore.Services.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class CartService : ICartService
    {
        private readonly BookStoreDbContext dbContext;

        public CartService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RemoveBook(int bookId)
        {
            var userBook = await this.dbContext.UserBook.FirstOrDefaultAsync(ub => ub.BookId == bookId && ub.IsDeleted == false);

            await this.RestoreBook(bookId, userBook.Pieces);

            userBook.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<CartListingResponseModel> ShowCart(int userId)
        {
            var books = await this.dbContext
                 .UserBook
                 .Where(u => u.UserId == userId && u.IsDeleted == false)
                 .Select(u => new CartViewModel
                 {
                     Pieces = u.Pieces,
                     BookId = u.BookId,
                     TotalPrice = u.Book.Price * u.Pieces,
                     PriceForEach = u.Book.Price,
                     ImageUrl = u.Book.ImageUrl,
                     Title = u.Book.Title,
                     AuthorName = u.Book.Authors.Select(a => a.Author.Fullname)
                 }).ToListAsync();

            var userBooks = new CartListingResponseModel
            {
                Books = books,
                TotalPrice = books.Select(x => x.TotalPrice).Sum()
            };

            return userBooks;
        }

        private async Task RestoreBook(int bookId, int pieces)
        {
            var book = await this.dbContext.Book.FirstOrDefaultAsync(b => b.Id == bookId);
            book.Quantity += pieces;

            if (book.IsAvailable == false)
            {
                book.IsAvailable = true;
            }
        }
    }
}
