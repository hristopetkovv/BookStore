using BookStore.Data.Data.Models;
using BookStore.Data.Data.Models.Enums;
using BookStore.Services.Common.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class VotesService : IVotesService
    {
        private readonly IAppDbContext dbContext;

        public VotesService(IAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetVotes(int bookId)
        {
            var votes = this.dbContext.Set<Vote>()
                .Where(v => v.BookId == bookId)
                .Sum(v => (int)v.Type);

            return votes;
        }

        public async Task VoteAsync(int bookId, int userId, bool isUpVote)
        {
            var vote = this.dbContext.Set<Vote>()
                .FirstOrDefault(v => v.BookId == bookId && v.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    BookId = bookId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.dbContext.Set<Vote>().AddAsync(vote);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
