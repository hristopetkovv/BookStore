using System.Collections.Generic;

namespace BookStore.ViewModels.Books
{
    public class SearchResultDto<T> where T : class
    {
        public IEnumerable<T> Result { get; set; } = new List<T>();

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }
}
