using BookStore.ViewModels.Books.Enums;

namespace BookStore.ViewModels.Books
{
    public class BookFilterRequestModel
    {
        public BookSortOrder SortOrder { get; set; }

        public string SearchByTitle { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}
