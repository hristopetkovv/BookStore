using BookStore.Data.Data.Common;

namespace BookStore.Data.Data.Models
{
    public class Comment : BaseModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Username { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
