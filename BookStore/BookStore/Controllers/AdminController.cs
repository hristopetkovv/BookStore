using BookStore.Services;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost]
        [Route("addbook")]
        public async Task<IActionResult> CreateBook([FromBody] BookRequestModel model)
        {
            await this.adminService.AddBook(model);

            return Ok();
        }
    }
}
