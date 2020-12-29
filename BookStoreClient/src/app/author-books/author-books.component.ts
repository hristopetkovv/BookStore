import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-author-books',
  templateUrl: './author-books.component.html',
  styleUrls: ['./author-books.component.css']
})
export class AuthorBooksComponent implements OnInit {
  @Input() book: string;
  @Input() bookId: number;

  constructor() { }

  ngOnInit(): void {
  }

}
