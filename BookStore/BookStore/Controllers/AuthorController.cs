﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Authors;
using BookStore.ViewModels.Authors.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AuthorResponseModel>> Get([FromQuery] AuthorSortOrder sortOrder)
        {
            return await this.authorService.GetAuthors(sortOrder);
        }
    }
}
