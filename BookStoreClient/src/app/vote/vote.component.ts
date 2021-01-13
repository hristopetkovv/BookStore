import { Component, Input, OnInit } from '@angular/core';
import { VoteService } from '../_services/vote.service';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent implements OnInit {
  @Input() bookId: number;
  @Input() upVotes: number;
  @Input() downVotes: number;

  constructor(private voteService: VoteService) { }

  ngOnInit(): void {
  }

  sendVote(bookId: number, isUpVote: boolean) {
    this.voteService.vote(bookId, isUpVote).subscribe(response => console.log(response));
  }

}
