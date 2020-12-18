import { Component, OnInit } from '@angular/core';
import { AuthorDto } from '../_models/author.dto';
import { AuthorService } from '../_services/author.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
  authors: AuthorDto[] = new Array<AuthorDto>();

  constructor(private authorService: AuthorService) { }

  ngOnInit(): void {
    this.getAuthors();
  }

  getAuthors() {
    this.authorService.getAuthors().subscribe(authors => this.authors = authors);
  }
}
