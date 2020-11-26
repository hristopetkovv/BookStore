using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        //// GET: api/<IdentityController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<IdentityController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<IdentityController>
        //[HttpPost]
        //public void Login([FromBody] LoginRequestModel model)
        //{
        //}

        // POST api/<IdentityController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var id = await this.identityService.Create(model);

            return Ok(id);
        }

        //// PUT api/<IdentityController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
    }
}
