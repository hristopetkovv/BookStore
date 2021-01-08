import { Component, OnInit } from '@angular/core';
import { BookFilterDto } from '../_models/book-filter.dto';
import { BookDto } from '../_models/book.dto';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-listing',
  templateUrl: './book-listing.component.html',
  styleUrls: ['./book-listing.component.css']
})
export class BookListingComponent implements OnInit {
  books: BookDto[] = [];
  totalCount: number;

  constructor(
    private bookService: BookService,
    public booksFilter: BookFilterDto
  ) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks(this.booksFilter)
      .subscribe(books => {
        this.books = books.result;
        this.totalCount = books.totalCount;
      });
  }

  pageChanged(event: any): void {
    this.booksFilter.pageNumber = event.page;
    this.getBooks();
  }
}
