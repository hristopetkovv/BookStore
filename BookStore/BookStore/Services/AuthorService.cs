using BookStore.Data;
using BookStore.ViewModels.Authors;
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

        public async Task<IEnumerable<AuthorResponseModel>> GetAuthors(string sortOrder)
        {
            IQueryable<AuthorResponseModel> authors = this.dbContext
                .Author
                .Select(a => new AuthorResponseModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Books = a.Books.Select(b => b.Book.Title),
                    BookId = a.Books.Select(b => b.BookId)
                });

            authors = sortOrder switch
            {
                "FirstName_descending" => authors.OrderByDescending(a => a.FirstName),
                "BooksCount" => authors.OrderByDescending(a => a.Books.Count()),
                "LastName" => authors.OrderBy(a => a.LastName),
                "LastName_descending" => authors.OrderByDescending(a => a.LastName),
                _ => authors.OrderBy(a => a.FirstName),
            };

            return await authors.ToListAsync();
        }
    }
}
