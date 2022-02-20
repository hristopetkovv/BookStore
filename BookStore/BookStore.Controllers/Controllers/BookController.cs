using BookStore.Services.Common.Interfaces;
using BookStore.Services.Services;
using BookStore.Services.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace BookStore.Controllers.Controllers
{
    public class BookController : BaseApiController
    {
        private readonly IBookService bookService;
        private readonly IUserContext userContext;

        public BookController(IBookService bookService, IUserContext userContext)
        {
            this.bookService = bookService;
            this.userContext = userContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<SearchResultDto<BookResponseModel>> GetBooks([FromQuery] BookFilterRequestModel model)
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
            await this.bookService.AddComent(id, this.userContext.Username, content.Comment);

            return Ok(id);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> BuyBook([FromRoute] int id, [FromBody] int pieces = 1)
        {
            await this.bookService.AddBookToCart(id, this.userContext.UserId, pieces);

            return Ok();
        }
    }
}
