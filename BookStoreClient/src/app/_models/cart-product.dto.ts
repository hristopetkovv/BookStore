export class CartProductDto {
    totalPrice: number;
    bookId: number;
    priceForEach: number;
    discount: number;
    imageUrl: string;
    title: string;
    authorName: string[]
    pieces: number;
}