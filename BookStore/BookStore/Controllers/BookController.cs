using BookStore.Services;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    public class BookController : BaseApiController
    {
        private readonly IBookService bookService;
        private readonly UserContext userContext;

        public BookController(IBookService bookService, UserContext userContext)
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
            await this.bookService.AddComent(id, this.userContext.UserName, content.Comment);

            return Ok(id);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> BuyBook([FromRoute] int id, [FromBody] int pieces = 1)
        {
            await this.bookService.AddBookToCart(id, this.userContext.UserName, pieces);

            return Ok();
        }
    }
}
