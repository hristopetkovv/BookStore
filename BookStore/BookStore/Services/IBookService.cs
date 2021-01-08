﻿using BookStore.ViewModels.Books;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<SearchResultDto<BookResponseModel>> GetBooks(BookFilterRequestModel filter);

        Task<BookDetailalsResponseModel> GetBookById(int id);

        Task<int> AddComent(int bookId, string username, string comment);

        Task AddBookToCart(int bookId, string username, int pieces);
    }
}
