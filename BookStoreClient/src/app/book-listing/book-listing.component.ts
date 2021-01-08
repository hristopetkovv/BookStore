import { Component, OnInit } from '@angular/core';
import { BookFilterDto } from '../_models/book-filter.dto';
import { BookDto } from '../_models/book.dto';
import { Pagination } from '../_models/pagination.dto';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-listing',
  templateUrl: './book-listing.component.html',
  styleUrls: ['./book-listing.component.css']
})
export class BookListingComponent implements OnInit {
  books: BookDto[] = [];
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 12;

  constructor(private bookService: BookService, public booksFilter: BookFilterDto) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks(this.booksFilter, this.pageNumber, this.pageSize).subscribe(books => {
      this.books = books.result;
      this.pagination = books.pagination;
    });
  }

  pageChanged(event: any): void {
    this.pageNumber = event.page;
    this.getBooks();
  }
}
