using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
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
