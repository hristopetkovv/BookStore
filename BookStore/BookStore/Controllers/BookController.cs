using BookStore.Services;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<BookResponseModel>> GetBooks([FromQuery] BookFilterRequestModel model)
        {
            return await this.bookService.GetBooks(model);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<BookDetailalsResponseModel> BookDetails([FromRoute] int id)
        {
            return await this.bookService.GetBookById(id);
        }

        [HttpPost]
        [Route("{id:int}/comments")]
        public async Task<IActionResult> AddComment([FromRoute] int id, [FromBody] CommentRequestModel content)
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.bookService.AddComent(id, username, content.Comment);

            return Ok(id);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> BuyBook([FromRoute] int id, [FromBody] int pieces = 1)
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.bookService.AddBookToCart(id, username, pieces);

            return Ok();
        }
    }
}
