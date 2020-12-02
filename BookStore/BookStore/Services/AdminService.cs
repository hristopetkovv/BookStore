using BookStore.Data;
using BookStore.Data.Models;
using BookStore.ViewModels.Books;
using System;
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
                Genre = new Genre { Name = model.Genre}
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
    }
}
