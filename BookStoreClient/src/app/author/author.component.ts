import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { AuthorDto } from '../_models/author.dto';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AuthorComponent implements OnInit {
  @Input() author: AuthorDto = new AuthorDto;

  constructor() { }

  ngOnInit(): void {
  }
}
