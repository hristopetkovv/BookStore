namespace BookStore.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
