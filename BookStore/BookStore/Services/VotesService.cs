using BookStore.Data.Data;
using BookStore.Data.Data.Models;
using BookStore.Data.Data.Models.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class VotesService : IVotesService
    {
        private readonly BookStoreDbContext dbContext;

        public VotesService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetVotes(int bookId)
        {
            var votes = this.dbContext
                .Vote
                .Where(v => v.BookId == bookId)
                .Sum(v => (int)v.Type);

            return votes;
        }

        public async Task VoteAsync(int bookId, int userId, bool isUpVote)
        {
            var vote = this.dbContext
                .Vote
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

                await this.dbContext.Vote.AddAsync(vote);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
