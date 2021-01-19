using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace BookStore.Services
{
    public class UserContext
    {
        public UserContext(IHttpContextAccessor context)
        {
            var user = context.HttpContext.User;

            if(!int.TryParse(GetClaimValue(user, "userId"), out int userId))
            {
                throw new System.Exception();
            }

            this.UserId = userId;
            this.Role = GetClaimValue(user, ClaimTypes.Role);
            this.UserName = GetClaimValue(user, ClaimTypes.NameIdentifier);
        }

        public int UserId { get; private set; }

        public string Role { get; private set; }

        public string UserName { get; private set; }

        private string GetClaimValue(ClaimsPrincipal claimsPrincipal, string claimName)
        {
            var claimValue = claimsPrincipal.Claims.FirstOrDefault(e => e.Type == claimName);
            return claimValue?.Value;
        }
    }
}
