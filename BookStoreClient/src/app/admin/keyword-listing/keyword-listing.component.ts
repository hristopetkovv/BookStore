import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { KeywordDto } from 'src/app/_models/keyword.dto';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-keyword-listing',
  templateUrl: './keyword-listing.component.html',
  styleUrls: ['./keyword-listing.component.css']
})
export class KeywordListingComponent implements OnInit {
  keywords: KeywordDto[] = [];
  bookId: number;

  constructor(private adminService: AdminService, private route: ActivatedRoute) { }


  ngOnInit(): void {
    this.bookId = +this.route.snapshot.paramMap.get('bookId');
    this.getKeywords(this.bookId);
  }

  getKeywords(bookId: number) {
    this.adminService.getKeywords(bookId).subscribe(keywords => this.keywords = keywords);
  }

  updateKeyword(keyword: KeywordDto) {
    this.adminService.updateKeyword(keyword).subscribe();
    location.reload();
  }

  removeKeyword(keywordId: number) {
    this.adminService.removeKeyword(keywordId).subscribe();
    location.reload();
  }
}
