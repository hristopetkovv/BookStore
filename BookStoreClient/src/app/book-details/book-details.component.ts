import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { BookDetailsDto } from '../_models/book-details.dto';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit, OnDestroy {
  book: BookDetailsDto;
  routeSub: Subscription;
  selectedId!: number;

  constructor(private route: ActivatedRoute, private bookService: BookService) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.selectedId = params['bookId'];
      this.getBook();
    })
  }

  getBook() {
    this.bookService.getBookDetails(this.selectedId)
      .subscribe(book => this.book = book);
  }

  ngOnDestroy(): void {
    if (!this.routeSub.closed) {
      this.routeSub.unsubscribe();
    }
  }
}
