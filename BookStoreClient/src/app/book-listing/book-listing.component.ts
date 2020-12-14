import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-listing',
  templateUrl: './book-listing.component.html',
  styleUrls: ['./book-listing.component.css']
})
export class BookListingComponent implements OnInit {
  books: any;

  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks().subscribe(books => this.books = books);
  }

  // getDetails() {
  //   this.router.navigateByUrl('/app/book/{id}')
  // }

}
