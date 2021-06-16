using System.Threading.Tasks;
using BookStore.Services.Services;
using BookStore.Services.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService accountService;

        public AccountController(
            IAccountService accountService
         )
        {
            this.accountService = accountService;
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseModel>> Register([FromBody] RegisterRequestModel model)
        {
            var user = await this.accountService.Register(model);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseModel>> Login([FromBody] LoginRequestModel model)
        {
            var user = await this.accountService.Login(model);

            return user;
        }
    }
}
