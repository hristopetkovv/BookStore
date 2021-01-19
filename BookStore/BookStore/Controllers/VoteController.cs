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
        private readonly UserContext userContext;

        public VoteController(IVotesService votesService, UserContext userContext)
        {
            this.votesService = votesService;
            this.userContext = userContext;
        }

        [HttpPost]
        public async Task<VoteResponseModel> Vote(VoteRequestModel model)
        {

            await this.votesService.VoteAsync(model.BookId, this.userContext.UserId, model.IsUpVote);

            var votes = this.votesService.GetVotes(model.BookId);

            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
