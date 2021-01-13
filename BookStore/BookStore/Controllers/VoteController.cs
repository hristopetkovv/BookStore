using BookStore.Services;
using BookStore.ViewModels.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class VoteController : BaseApiController
    {
        private readonly IVotesService votesService;

        public VoteController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        public async Task<VoteResponseModel> Vote(VoteRequestModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            await this.votesService.VoteAsync(model.BookId, userId, model.IsUpVote);

            var votes = this.votesService.GetVotes(model.BookId);

            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
