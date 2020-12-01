using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Data.Models.Enums;
using BookStore.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            var book = await this.dbContext.Book.FirstOrDefaultAsync(b => b.Id == bookId);
            book.Quantity++;

            if (book.IsAvailable == false)
            {
                book.IsAvailable = true;
            }

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

        public async Task CreateOrder(int userId, decimal totalPrice)
        {
            var order = new Order
            {
                UserId = userId,
                BoughtOn = DateTime.UtcNow,
                Status = Status.Pending,
                TotalPrice = totalPrice,
            };

            var userBooks = dbContext
                .UserBook
                .Where(ub => ub.UserId == userId)
                .ToList();

            foreach (var book in userBooks)
            {
                book.IsDeleted = true;
            }

            await this.dbContext.Order.AddAsync(order);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrders(int userId)
        {
            IQueryable<Order> orders = this.dbContext.Order;

            var result = await orders
                .Select(o => new OrderResponseModel
                {
                    Id = o.Id,
                    TotalPrice = o.TotalPrice,
                    BoughtOn = o.BoughtOn,
                    Status = o.Status,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    Address = o.User.Address,
                    TelephoneNumber = o.User.TelephoneNumber,
                    Email = o.User.Email
                })
                .ToListAsync();

            return result;
        }
    }
}
