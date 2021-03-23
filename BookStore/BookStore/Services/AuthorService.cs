using BookStore.Data.Data;
using BookStore.Data.Data.Models;
using BookStore.ExtensionMethods;
using BookStore.ViewModels.Authors;
using BookStore.ViewModels.Authors.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreDbContext dbContext;

        public AuthorService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AuthorResponseModel>> GetAuthors(AuthorSortOrder sortOrder)
        {
            IQueryable<Author> authors = this.dbContext.Author;

            var result = await authors
                .OrderAuthors(sortOrder)
                .Select(a => new AuthorResponseModel
                {
                    Id = a.Id,
                    Fullname = a.Fullname,
                    Books = a.Books.Select(b => b.Book.Title),
                    BookId = a.Books.Select(b => b.BookId)
                }).ToListAsync();

            return result;
        }
    }
}
