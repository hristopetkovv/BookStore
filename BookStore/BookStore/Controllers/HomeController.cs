using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //[HttpGet]
        //public async Task<IEnumerable<BookResponseModel>> Cart()
        //{
        //    return Ok();
        //}
    }
}
