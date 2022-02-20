using BookStore.Services.Common.Interfaces;
using BookStore.Services.Services;
using BookStore.Services.ViewModels.Votes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Controllers
{
    public class VoteController : BaseApiController
    {
        private readonly IVotesService votesService;
        private readonly IUserContext userContext;

        public VoteController(IVotesService votesService, IUserContext userContext)
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
