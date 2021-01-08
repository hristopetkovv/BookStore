using BookStore.Data;
using BookStore.Data.Models;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AdminService : IAdminService
    {
        private readonly BookStoreDbContext dbContext;

        public AdminService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBook(BookRequestModel model)
        {
            var book = new Book
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                IsAvailable = model.IsAvailable,
                Price = model.Price,
                PublishedOn = model.PublishedOn,
                PublishHouse = model.PublishHouse,
                Quantity = model.Quantity,
                Title = model.Title,
                Genre = new Genre { Name = model.Genre},
            };

            var bookAuthor = new BookAuthor
            {
                Book = book,
                Author = new Author { FirstName = model.AuthorFirstName, LastName = model.AuthorLastName}
            };

            book.Authors.Add(bookAuthor);

            dbContext.Book.Add(book);
            
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrders()
        {
            var orders = await dbContext
                .Order
                .Select(o => new OrderResponseModel
                {
                    Id = o.Id,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    Email = o.User.Email,
                    Address = o.User.Address,
                    BoughtOn = o.BoughtOn,
                    Status = o.Status,
                    TelephoneNumber = o.User.PhoneNumber,
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();

            return orders;
        }

        public async Task UpdateOrder(OrderUpdateRequestModel model)
        {
            var order = await dbContext.Order.FirstOrDefaultAsync(x => x.Id == model.OrderId);

            order.Status = model.Status;

            await dbContext.SaveChangesAsync();
        }
    }
}
