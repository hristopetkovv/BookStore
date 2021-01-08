using BookStore.Helpers;
using BookStore.ViewModels.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<PagedList<BookResponseModel>> GetBooks(BookFilterRequestModel model, BookParams bookParams);

        Task<BookDetailalsResponseModel> GetBookById(int id);

        Task<int> AddComent(int bookId, string username, string comment);

        Task AddBookToCart(int bookId, string username, int pieces);
    }
}
