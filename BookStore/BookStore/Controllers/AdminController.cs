using BookStore.Services;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IEnumerable<OrderResponseModel>> Orders()
        {
            return await this.adminService.GetOrders();
        }

        [HttpPost]
        [Route("addbook")]
        public async Task<IActionResult> CreateBook([FromBody] BookRequestModel model)
        {
            await this.adminService.AddBook(model);

            return Ok();
        }

        [HttpPut]
        public async Task UpdateOrder([FromBody] OrderUpdateRequestModel model)
        {
            await this.adminService.UpdateOrder(model);
        }
    }
}
