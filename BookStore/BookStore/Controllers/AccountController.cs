using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
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

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseModel>> Register([FromBody] RegisterRequestModel model)
        {
            var user = await this.accountService.Create(model);

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
