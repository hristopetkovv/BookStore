using BookStore.Data.Data.Models;

namespace BookStore.Services.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
