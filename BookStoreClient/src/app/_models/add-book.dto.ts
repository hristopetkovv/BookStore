export class AddBookDto {
    title: string;
    description: string;
    imageUrl: string;
    price: number;
    quantity: number;
    isAvailable: boolean;
    publishHouse: string;
    authorFirstName: string;
    authorLastName: string;
    genre: string;
    keywords: string[] = [];
    publishedOn: Date;
}