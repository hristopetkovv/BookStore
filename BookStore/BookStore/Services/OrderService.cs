using BookStore.Data.Data;
using BookStore.Data.Data.Models;
using BookStore.Data.Data.Models.Enums;
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
            IQueryable<Order> orders = this.dbContext.Order.Where(o => o.UserId == userId);

            var result = await orders
                .Select(o => new OrderResponseModel
                {
                    Id = o.Id,
                    TotalPrice = o.TotalPrice,
                    BoughtOn = o.BoughtOn,
                    Status = o.Status.ToString(),
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    Address = o.User.Address,
                    TelephoneNumber = o.User.PhoneNumber,
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
        }
    }
}
