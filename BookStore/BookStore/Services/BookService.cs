using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Data.Models.Enums;
using BookStore.ExtensionMethods;
using BookStore.ViewModels.Books;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task AddBookToCart(int bookId, int userId, int pieces)
        {
            var book = await dbContext
                .Book
                .FirstOrDefaultAsync(b => b.Id == bookId);

            var user = await dbContext
                .User
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (book.IsAvailable == false)
            {
                throw new InvalidOperationException("The Book is not available.");
            }

            if (book.Quantity < pieces)
            {
                throw new InvalidOperationException("There are not enought pieces in store.");
            }

            book.Quantity -= pieces;

            if (book.Quantity == 0)
            {
                book.IsAvailable = false;
            }

            var userBook = new UserBook
            {
                User = user,
                Book = book,
                Pieces = pieces,
            };

            await this.dbContext.UserBook.AddAsync(userBook);
            await this.dbContext.SaveChangesAsync();
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
                    AuthorName = b.Authors.Select(a => a.Author.Fullname),
                    Comments = b.Comments.Select(c => new BookCommentResponseModel
                    {
                        Text = c.Text,
                        Username = c.Username,
                        CreatedOn = c.CreatedOn
                    })

                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookResponseModel>> GetBooks(BookFilterRequestModel model)
        {
            IQueryable<Book> books = this.dbContext.Book;

            var result = await books
                .OrderBooks(model)
                .SortBooks(model)
                .Select(x => new BookResponseModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    AuthorName = x.Authors.Select(a => a.Author.Fullname)
                })
                .ToListAsync();

            return result;
        }
    }
}
