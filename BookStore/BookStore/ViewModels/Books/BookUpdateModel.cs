namespace BookStore.ViewModels.Books
{
    public class BookUpdateModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string PublishHouse { get; set; }

        public string ImageUrl { get; set; }
    }
}
