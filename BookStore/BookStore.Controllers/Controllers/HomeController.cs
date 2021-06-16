using BookStore.Services.Services.Helpers;
using BookStore.Services.Services;
using BookStore.Services.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Controllers
{
    public class HomeController : BaseApiController
    {
        private readonly IUserService userService;
        private readonly UserContext userContext;

        public HomeController(IUserService userService, UserContext userContext)
        {
            this.userService = userService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<UserInformationResponseModel> GetUser()
        {
            return await this.userService.GetUser(this.userContext.UserId.Value);
        }

        [HttpPut]
        public async Task UpdateUser(UserInformationResponseModel model)
        {
            await this.userService.UpdateUser(model);
        }
    }
}
