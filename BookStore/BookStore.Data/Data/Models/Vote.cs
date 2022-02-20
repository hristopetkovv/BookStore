using BookStore.Data.Data.Models.Enums;

namespace BookStore.Data.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public VoteType Type { get; set; }
    }
}
