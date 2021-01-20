import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AddBookDto } from 'src/app/_models/add-book.dto';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {
  book: AddBookDto = new AddBookDto();
  fieldArray: Array<any> = [];
  newAttribute: string;

  constructor(private adminService: AdminService, private router: Router) { }

  ngOnInit(): void {
  }

  addBook() {
    this.adminService.addBook(this.book).subscribe();
    this.router.navigateByUrl('/book');
  }

  addRow() {
    this.fieldArray.push(this.newAttribute)
    this.book.keywords.push(this.newAttribute);
    this.newAttribute = null;
  }

  deleteFieldValue(index) {
    this.book.keywords.splice(index, 1)
    this.fieldArray.splice(index, 1);
  }

  cancel() {
    this.router.navigateByUrl('/')
  }
}
