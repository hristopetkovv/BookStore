using BookStore.Data;
using BookStore.Data.Models;
using BookStore.ViewModels.Books;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext dbContext;

        public BookService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddComent(int bookId, BookCommentRequestModel model)
        {
            var comment = new Comment
            {
                Text = model.Text,
                Username = model.Username,
                BookId = bookId
            };

            this.dbContext.Comment.Add(comment);

            await this.dbContext.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<BookDetailalsResponseModel> GetBookById(int id)
        {
            return await this.dbContext
                .Book
                .Where(b => b.Id == id)
                .Select(b => new BookDetailalsResponseModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    Description = b.Description,
                    IsAvailable = b.IsAvailable,
                    PublishHouse = b.PublishHouse,
                    PublishedOn = b.PublishedOn,
                    Genre = b.Genre.Name,
                    AuthorName = b.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName),
                    Comments = b.Comments.Select(c => c.Text),
                    CommentUser = b.Comments.Select(c => c.Username)
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookResponseModel>> GetBooks()
        {
            return await this.dbContext
                .Book
                .Select(x => new BookResponseModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    AuthorName = x.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName)
                })
                .ToListAsync();
        }
    }
}
