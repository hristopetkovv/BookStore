import { Component, OnInit } from '@angular/core';
import { BookDto } from '../_models/book.dto';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-listing',
  templateUrl: './book-listing.component.html',
  styleUrls: ['./book-listing.component.css']
})
export class BookListingComponent implements OnInit {
  books: BookDto[] = [];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks().subscribe(books => this.books = books);
  }
}
