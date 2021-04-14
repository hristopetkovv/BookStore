using BookStore.Data.Data;
using BookStore.Data.Data.Models;
using BookStore.Data.Data.Models.Enums;
using BookStore.ExtensionMethods;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Comments;
using Microsoft.EntityFrameworkCore;
using System;
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
                .SingleOrDefaultAsync(b => b.Id == bookId);

            var user = await dbContext
                .User
                .SingleOrDefaultAsync(u => u.Id == userId);

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

        public async Task<int> AddComent(int bookId, string username, string comment)
        {
            var newComment = new Comment
            {
                Text = comment,
                Username = username,
                BookId = bookId
            };

            this.dbContext.Comment.Add(newComment);

            await this.dbContext.SaveChangesAsync();

            return newComment.Id;
        }

        public async Task<BookDetailalsResponseModel> GetBookById(int id)
        {
            var book = await this.dbContext
                .Book
                .Where(b => b.Id == id)
                .Select(b => new BookDetailalsResponseModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Quantity = b.Quantity,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    Description = b.Description,
                    IsAvailable = b.IsAvailable,
                    PublishHouse = b.PublishHouse,
                    PublishedOn = b.PublishedOn,
                    Genre = b.Genre.Name,
                    Keywords = b.BookKeyWords.Where(kw => kw.BookId == id).Select(kw => kw.Keyword).ToList(),
                    AuthorName = b.Authors.Select(a => a.Author.Fullname),
                    DownVotes = b.Votes.Where(v => v.Type == VoteType.DownVote).Sum(v => (int) v.Type),
                    UpVotes = b.Votes.Where(v => v.Type == VoteType.UpVote).Sum(v => (int)v.Type),
                    Comments = b.Comments.Select(c => new CommentResponseModel
                    {
                        Comment = c.Text,
                        Username = c.Username,
                        CreatedOn = c.CreatedOn
                    }).OrderByDescending(c => c.CreatedOn)

                })
                .FirstOrDefaultAsync();

            if (book.DownVotes < 0)
            {
                book.DownVotes *= -1;
            }

            return book;
        }

        public async Task<SearchResultDto<BookResponseModel>> GetBooks(BookFilterRequestModel filter)
        {
            IQueryable<BookResponseModel> query = this.dbContext.Book
                .Where(b => b.IsAvailable == true)
                .OrderBooks(filter)
                .SortBooks(filter)
                .Select(x => new BookResponseModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    AuthorName = x.Authors.Select(a => a.Author.Fullname)
                });

            return await query.WithPaginationAsync(filter.PageNumber, filter.PageSize);
        }
    }
}
