using BookStore.Services;
using BookStore.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : BaseApiController
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<UserInformationResponseModel> GetUser()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            return await this.userService.GetUser(userId);
        }
    }
}
