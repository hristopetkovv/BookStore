using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Data.Models.Enums;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Books.Enums;
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
                return;
            }

            if (book.Quantity < pieces)
            {
                return;
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
                Status = Status.Pending,
                BoughtOn = DateTime.UtcNow
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
                .AsNoTracking()
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
            IQueryable<BookResponseModel> books = this.dbContext
                .Book
                .Select(x => new BookResponseModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    AuthorName = x.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName)
                });

            if (!string.IsNullOrEmpty(model.SearchByAuthorOrTitle))
            {
                books = books.Where(b => b.Title.Contains(model.SearchByAuthorOrTitle) || b.AuthorName.Contains(model.SearchByAuthorOrTitle));
            }

            switch (model.SortOrder)
            {
                case BookSortOrder.PriceDescending:
                    books = books.OrderByDescending(b => b.Price);
                    break;
                case BookSortOrder.Price:
                    books = books.OrderBy(b => b.Price);
                    break;
                case BookSortOrder.TitleDescending:
                    books = books.OrderByDescending(b => b.Title);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            return await books.AsNoTracking().ToListAsync();
        }
    }
}
