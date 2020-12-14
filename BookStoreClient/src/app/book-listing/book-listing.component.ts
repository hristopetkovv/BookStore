import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookDto } from '../_models/bookDto';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-listing',
  templateUrl: './book-listing.component.html',
  styleUrls: ['./book-listing.component.css']
})
export class BookListingComponent implements OnInit {
  books: BookDto[] = [];

  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks().subscribe(books => this.books = books);
  }
}
