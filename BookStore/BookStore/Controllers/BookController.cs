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
        public async Task<IEnumerable<BookResponseModel>> Get()
        {
            return await this.bookService.GetBooks();
        }

        // GET api/<BookController>/5
        [HttpGet("{id:int}")]
        public async Task<BookDetailalsResponseModel> Get([FromRoute] int id)
        {
            return await this.bookService.GetBookById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
