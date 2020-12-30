import { CartProductDto } from "./cart-product.dto";

export class CartDto {
    totalPrice: number;
    books: CartProductDto[]
}