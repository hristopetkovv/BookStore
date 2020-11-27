using BookStore.ViewModels.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseModel>> GetAuthors();
    }
}
