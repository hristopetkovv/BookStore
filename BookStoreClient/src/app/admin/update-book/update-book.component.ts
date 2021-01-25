import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookUpdateDto } from 'src/app/_models/book-update.dto';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {
  book: BookUpdateDto;
  bookId: number;

  constructor(private adminService: AdminService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.bookId = +this.route.snapshot.paramMap.get('bookId');
    this.getBook(this.bookId);
  }

  getBook(bookId: number) {
    this.adminService.getBook(bookId).subscribe(book => this.book = book);
  }

  cancel() {
    this.router.navigateByUrl('/')
  }

  update() {

  }
}
