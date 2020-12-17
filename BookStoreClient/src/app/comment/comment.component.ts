import { Component, Input, OnInit } from '@angular/core';
import { CommentDto } from '../_models/comment.dto';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  @Input() comment: CommentDto


  constructor() { }

  ngOnInit(): void {
  }
}
