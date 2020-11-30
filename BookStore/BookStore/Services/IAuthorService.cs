using BookStore.ViewModels.Authors;
using BookStore.ViewModels.Authors.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseModel>> GetAuthors(AuthorSortOrder sortOrder);
    }
}
