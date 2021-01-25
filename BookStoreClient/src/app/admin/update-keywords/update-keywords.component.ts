import { Component, OnInit } from '@angular/core';
import { BookFilterDto } from 'src/app/_models/book-filter.dto';
import { BookDto } from 'src/app/_models/book.dto';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-update-keywords',
  templateUrl: './update-keywords.component.html',
  styleUrls: ['./update-keywords.component.css']
})
export class UpdateKeywordsComponent implements OnInit {
  books: BookDto[] = [];

  constructor(private bookService: BookService, public booksFilter: BookFilterDto) { }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks(this.booksFilter).subscribe(books => this.books = books.result);
  }
}
