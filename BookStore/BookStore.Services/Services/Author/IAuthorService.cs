using BookStore.Services.ViewModels.Authors;
using BookStore.Services.ViewModels.Authors.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseModel>> GetAuthors(AuthorSortOrder sortOrder);
    }
}
