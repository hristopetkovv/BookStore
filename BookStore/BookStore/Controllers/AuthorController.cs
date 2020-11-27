using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Authors;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<AuthorResponseModel>> Get()
        {
            return await this.authorService.GetAuthors();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
