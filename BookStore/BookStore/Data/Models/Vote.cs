using BookStore.Data.Common;
using BookStore.Data.Models.Enums;

namespace BookStore.Data.Models
{
    public class Vote : BaseModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public VoteType Type { get; set; }
    }
}
