using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<CartResponseModel> Cart()
        {
            return this.userService.ShowCart(2);
        }
    }
}
