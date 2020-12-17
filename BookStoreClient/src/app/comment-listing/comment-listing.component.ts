import { Component, Input, OnInit } from '@angular/core';
import { CommentDto } from '../_models/comment.dto';
import { AuthService } from '../_services/auth.service';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-comment-listing',
  templateUrl: './comment-listing.component.html',
  styleUrls: ['./comment-listing.component.css']
})
export class CommentListingComponent implements OnInit {
  @Input() comments: CommentDto[];
  isLoggedIn: boolean;
  @Input() bookId: number;

  constructor(private authService: AuthService, private bookService: BookService) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedInUser;
    console.log(this.bookId);
  }

  createComment(comment: string) {
    this.bookService.createComment(comment, this.bookId)
      .subscribe();
  }
}
