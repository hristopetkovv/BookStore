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
  booksFilter = new BookFilterDto();

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks(this.booksFilter).subscribe(books => this.books = books);
  }

  printdd() {
    console.log(this.booksFilter.sortOrder);
  }
}
