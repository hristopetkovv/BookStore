import { Component, OnInit } from '@angular/core';
import { AuthorDto } from '../_models/author.dto';
import { AuthorService } from '../_services/author.service';

@Component({
  selector: 'app-author-listing',
  templateUrl: './author-listing.component.html',
  styleUrls: ['./author-listing.component.css']
})
export class AuthorListingComponent implements OnInit {
  authors: AuthorDto[] = new Array<AuthorDto>();
  sortOrder: string = "FirstName";

  constructor(private authorService: AuthorService) { }

  ngOnInit(): void {
    this.getAuthors();
  }

  getAuthors() {
    this.authorService.getAuthors(this.sortOrder).subscribe(authors => this.authors = authors);
  }
}
