import { CommentDto } from './comment.dto';

export class BookDetailsDto {
    id: number;
    title: string;
    imageUrl: string;
    price: number;
    authorName: string[];
    genre: string;
    quantity: number;
    description: string;
    isAvailable: boolean;
    publishHouse: string;
    publishedOn: Date;
    comments: CommentDto[];
    votesCount: number;
    downVotes: number;
    upVotes: number;
}