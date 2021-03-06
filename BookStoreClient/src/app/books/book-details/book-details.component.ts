import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { BookDetailsDto } from '../../_models/book-details.dto';
import { BookService } from '../../_services/book.service';
import { VoteService } from '../../_services/vote.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit, OnDestroy {
  book: BookDetailsDto;
  routeSub: Subscription;
  selectedId!: number;
  showComment: boolean = false;

  constructor(private route: ActivatedRoute, private bookService: BookService, private router: Router, private voteService: VoteService) { }

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

  getComments() {
    this.showComment = !this.showComment;
  }

  buyBook(quantity: any) {
    let pieces: number = +quantity;
    if (pieces < 1) {
      pieces = 1;
    }
    this.bookService.buyBook(this.selectedId, pieces).subscribe();
    this.router.navigateByUrl('/book');
  }

  ngOnDestroy(): void {
    if (!this.routeSub.closed) {
      this.routeSub.unsubscribe();
    }
  }
}
