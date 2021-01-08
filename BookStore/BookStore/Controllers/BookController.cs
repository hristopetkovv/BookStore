using BookStore.Data.Models;
using BookStore.ExtensionMethods;
using BookStore.Helpers;
using BookStore.Services;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<BookResponseModel>>> GetBooks([FromQuery] BookFilterRequestModel model,[FromQuery] BookParams bookParams)
        {
            var books = await this.bookService.GetBooks(model, bookParams);

            Response.AddPaginationHeader(books.CurrentPage, books.PageSize, books.TotalCount, books.TotalPages);

            return Ok(books);
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
