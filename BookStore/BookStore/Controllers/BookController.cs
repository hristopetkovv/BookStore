using BookStore.Services;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    public class BookController : BaseApiController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<BookResponseModel>> GetBooks([FromQuery] BookFilterRequestModel model)
        {
            return await this.bookService.GetBooks(model);
        }

        [HttpGet("{id:int}")]
        public async Task<BookDetailalsResponseModel> BookDetails([FromRoute] int id)
        {
            return await this.bookService.GetBookById(id);
        }

        [Authorize]
        [HttpPost]
        [Route("{id:int}/comments")]
        public async Task<IActionResult> AddComment([FromRoute] int id, [FromBody] BookCommentRequestModel model)
        {
            await this.bookService.AddComent(id, model);

            return Ok(id);
        }

        [Authorize]
        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> BuyBook([FromRoute] int id, [FromQuery] int pieces = 1)
        {
            await this.bookService.AddBookToCart(id, 1, pieces);

            return Ok();
        }
    }
}
