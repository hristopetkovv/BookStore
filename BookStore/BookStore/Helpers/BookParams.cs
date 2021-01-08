﻿namespace BookStore.Helpers
{
    public class BookParams
    {
        private int pageSize = 10;

        private const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => this.pageSize;
            set => this.pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

    }
}
