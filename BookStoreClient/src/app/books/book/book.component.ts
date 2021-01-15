import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { BookDto } from '../../_models/book.dto';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BookComponent implements OnInit {
  @Input() book: BookDto = new BookDto;

  constructor() { }

  ngOnInit(): void {
  }
}
