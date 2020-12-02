using BookStore.ViewModels.Books;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAdminService
    {
        Task AddBook(BookRequestModel model);
    }
}
