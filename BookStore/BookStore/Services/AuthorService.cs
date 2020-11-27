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

        public async Task<IEnumerable<AuthorResponseModel>> GetAuthors()
        {
            return await this.dbContext
                .Author
                .Select(a => new AuthorResponseModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Books = a.Books.Select(b => b.Book.Title),
                    BookId = a.Books.Select(b => b.BookId)
                })
                .ToListAsync();
        }
    }
}
