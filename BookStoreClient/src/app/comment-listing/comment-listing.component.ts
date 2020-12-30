import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(private authService: AuthService, private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedInUser;
  }

  createComment(comment: string) {
    this.bookService.createComment(comment, this.bookId)
      .subscribe();

    location.reload();
  }
}
