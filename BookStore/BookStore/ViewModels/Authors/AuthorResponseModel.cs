using System.Collections.Generic;

namespace BookStore.ViewModels.Authors
{
    public class AuthorResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<int> BookId { get; set; }

        public IEnumerable<string> Books { get; set; }
    }
}
