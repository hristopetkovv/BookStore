using BookStore.Data.Data;
using BookStore.Data.Data.Models;
using BookStore.Services.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly IAppDbContext dbContext;

        public ErrorController(IAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [AllowAnonymous]
        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            var thing = this.dbContext.Set<User>().Find(-1);

            if (thing == null)
            {
                return NotFound();
            }

            return Ok(thing);
        }

        [AllowAnonymous]
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
                var thing = this.dbContext.Set<User>().Find(-1);

                var thingToReturn = thing.ToString();

                return thingToReturn;
        }

        [AllowAnonymous]
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not good request");
        }
    }
}
