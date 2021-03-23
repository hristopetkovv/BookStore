using BookStore.Data.Data;
using BookStore.Data.Data.Models;
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

        public async Task<IEnumerable<BookKeywordsModel>> GetBookKeywords(int bookId)
        {
            var keywords = await this.dbContext
                .BookKeyWords
                .Where(bk => bk.BookId == bookId)
                .Select(bk => new BookKeywordsModel
                {
                    Id = bk.Id,
                    Keyword = bk.Keyword,
                    BookId = bk.BookId
                })
                .ToListAsync();

            return keywords;
        }

        public async Task AddBook(BookRequestModel model)
        {
            var book = new Book
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                IsAvailable = true,
                Price = model.Price,
                PublishedOn = model.PublishedOn,
                PublishHouse = model.PublishHouse,
                Quantity = model.Quantity,
                Title = model.Title,
                Genre = new Genre { Name = model.Genre },
            };

            foreach (var keyword in model.Keywords)
            {
                var bookKeyword = new BookKeyWords
                {
                    Keyword = keyword,
                    BookId = book.Id,
                };

                book.BookKeyWords.Add(bookKeyword);
            }

            var author = this.dbContext
                .Author
                .FirstOrDefault(a => a.FirstName.ToLower() == model.AuthorFirstName.ToLower() && a.LastName.ToLower() == model.AuthorLastName.ToLower());

            var bookAuthor = new BookAuthor
            {
                Book = book
            };

            if (author != null)
            {
                bookAuthor.AuthorId = author.Id;
                bookAuthor.Author = author;
                dbContext.BookAuthor.Add(bookAuthor);
            }
            else
            {
                bookAuthor.Author = new Author { FirstName = model.AuthorFirstName, LastName = model.AuthorLastName };
                book.Authors.Add(bookAuthor);
            }

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
                    Status = o.Status.ToString(),
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

        public async Task RemoveKeyword(int keywordId)
        {
            var keyword = await this.dbContext
                .BookKeyWords
                .FirstOrDefaultAsync(bk => bk.Id == keywordId);

            this.dbContext.BookKeyWords.Remove(keyword);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateKeyword(BookKeywordsModel model)
        {
            var keyword = await this.dbContext
                .BookKeyWords
                .FirstOrDefaultAsync(bk => bk.Id == model.Id);

            keyword.Keyword = model.Keyword;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(int bookId, BookUpdateModel model)
        {
            var book = await this.dbContext.Book.FirstOrDefaultAsync(b => b.Id == bookId);

            book.Title = model.Title;
            book.Description = model.Description;
            book.Price = model.Price;
            book.Quantity = model.Quantity;
            book.ImageUrl = model.ImageUrl;
            book.PublishHouse = model.PublishHouse;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<BookUpdateModel> GetBook(int bookId)
        {
            var book = await this.dbContext
                .Book
                .Where(b => b.Id == bookId)
                .Select(b => new BookUpdateModel
                {
                    Title = b.Title,
                    Description = b.Description,
                    Price = b.Price,
                    Quantity = b.Quantity,
                    PublishHouse = b.PublishHouse,
                    ImageUrl = b.ImageUrl,
                })
                .FirstOrDefaultAsync();

            return book;
        }
    }
}
