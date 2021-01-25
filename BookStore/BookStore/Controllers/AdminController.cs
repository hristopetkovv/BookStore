using BookStore.Services;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseApiController
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

        [HttpGet]
        [AllowAnonymous]
        [Route("keywords/{bookId:int}")]
        public async Task<IEnumerable<BookKeywordsModel>> GetKeywords([FromRoute]int bookId)
        {
           return await this.adminService.GetBookKeywords(bookId);
        }

        [HttpDelete]
        [Route("keywords")]
        public async Task DeleteKeyword([FromQuery]int keywordId)
        {
            await this.adminService.RemoveKeyword(keywordId);
        }

        [HttpPut]
        [Route("keywords")]
        public async Task UpdateKeyword([FromBody] BookKeywordsModel model)
        {
            await this.adminService.UpdateKeyword(model);
        }
    }
}
