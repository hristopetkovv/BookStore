using BookStore.ViewModels.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseModel>> GetBooks(BookFilterRequestModel model);

        Task<BookDetailalsResponseModel> GetBookById(int id);

        Task<int> AddComent(int bookId, BookCommentRequestModel model);
    }
}
