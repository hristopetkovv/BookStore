using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Data.Models.Enums;
using BookStore.ViewModels.Home;
using BookStore.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly BookStoreDbContext dbContext;

        public OrderService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            if (totalPrice == 0)
            {
                throw new InvalidOperationException("Your cart is empty.");
            }

            this.ClearCart(userId);

            await this.dbContext.Order.AddAsync(order);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrders(int userId)
        {
            IQueryable<Order> orders = this.dbContext.Order;

            var result = await orders
                .Where(o => o.UserId == userId)
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

        private void ClearCart(int userId)
        {
            var userBooks = dbContext
                .UserBook
                .Where(ub => ub.UserId == userId)
                .ToList();

            dbContext.UserBook.RemoveRange(userBooks);

            //foreach (var book in userBooks)
            //{
            //    book.IsDeleted = true;
            //}
        }
    }
}
