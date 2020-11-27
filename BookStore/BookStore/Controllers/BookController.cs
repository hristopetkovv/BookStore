using BookStore.Services;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<BookResponseModel>> Get([FromQuery] BookFilterRequestModel model)
        {
            return await this.bookService.GetBooks(model);
        }

        // GET api/<BookController>/5
        [HttpGet("{id:int}")]
        public async Task<BookDetailalsResponseModel> Get([FromRoute] int id)
        {
            return await this.bookService.GetBookById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        [Route("{id:int}/comments")]
        public async Task<IActionResult> Post([FromRoute] int id, [FromBody] BookCommentRequestModel model)
        {
            await this.bookService.AddComent(id, model);

            return Ok(id);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> AddBookToCart([FromRoute] int id, [FromQuery] int pieces)
        {
            await this.bookService.AddBookToCart(id, 2, pieces);

            return Ok();
        }
    }
}
