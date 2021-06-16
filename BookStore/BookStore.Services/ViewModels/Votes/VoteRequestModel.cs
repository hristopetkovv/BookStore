namespace BookStore.Services.ViewModels.Votes
{
    public class VoteRequestModel
    {
        public int BookId { get; set; }

        public bool IsUpVote { get; set; }
    }
}
