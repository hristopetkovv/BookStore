using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public TestController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        // POST api/<IdentityController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var id = await this.identityService.Create(model);

            return Ok(id);
        }
    }
}
