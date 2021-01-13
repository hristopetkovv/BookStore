using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IVotesService
    {
        Task VoteAsync(int bookId, int userId, bool isUpVote);

        int GetVotes(int bookId);
    }
}
