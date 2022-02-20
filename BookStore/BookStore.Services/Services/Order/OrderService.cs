using BookStore.Data.Data;
using BookStore.Data.Data.Models;
using BookStore.Data.Data.Models.Enums;
using BookStore.Services.Common.Interfaces;
using BookStore.Services.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAppDbContext dbContext;

        public OrderService(IAppDbContext dbContext)
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

            await this.dbContext.Set<Order>().AddAsync(order);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrders(int userId)
        {
            IQueryable<Order> orders = this.dbContext.Set<Order>().Where(o => o.UserId == userId);

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
            var userBooks = dbContext.Set<UserBook>()
                .Where(ub => ub.UserId == userId)
                .ToList();

            dbContext.Set<UserBook>().RemoveRange(userBooks);
        }
    }
}
