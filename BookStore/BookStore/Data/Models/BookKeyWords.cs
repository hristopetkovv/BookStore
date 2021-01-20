namespace BookStore.Data.Models
{
    public class BookKeyWords
    {
        public int Id { get; set; }

        public string Keyword { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
