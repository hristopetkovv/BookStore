﻿using BookStore.Data;
using BookStore.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class UserService : IUserService
    {
        private readonly BookStoreDbContext dbContext;

        public UserService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RemoveBook(int bookId)
        {
            var userBook = await this.dbContext.UserBook.FirstOrDefaultAsync(ub => ub.BookId == bookId);

            await this.ReturnBook(bookId);

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
                books = books,
                TotalPrice = books.Select(x => x.TotalPrice).Sum()
            };

            return userBooks;
        }

        private async Task ReturnBook(int bookId)
        {
            var book = await this.dbContext.Book.FirstOrDefaultAsync(b => b.Id == bookId);
            book.Quantity++;

            if (book.IsAvailable == false)
            {
                book.IsAvailable = true;
            }
        }
    }
}
