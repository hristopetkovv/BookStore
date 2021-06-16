using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface IVotesService
    {
        Task VoteAsync(int bookId, int userId, bool isUpVote);

        int GetVotes(int bookId);
    }
}
