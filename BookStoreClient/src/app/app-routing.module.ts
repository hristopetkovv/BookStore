import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorListingComponent } from './authors/author-listing/author-listing.component';
import { BookDetailsComponent } from './books/book-details/book-details.component';
import { BookListingComponent } from './books/book-listing/book-listing.component';
import { CartListingComponent } from './carts/cart-listing/cart-listing.component';
import { CartComponent } from './carts/cart/cart.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './account/login/login.component';
import { OrderListingComponent } from './order-listing/order-listing.component';
import { ProfileComponent } from './account/profile/profile.component';
import { RegisterComponent } from './account/register/register.component';
import { NotFoundComponent } from './_errors/not-found/not-found.component';
import { TestErrorsComponent } from './_errors/test-errors/test-errors.component';

const routes: Routes = [
  { path: '', component: BookListingComponent },
  { path: 'login', component: LoginComponent },
  { path: 'book', component: BookListingComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'home', component: HomeComponent },
  { path: 'author', component: AuthorListingComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'book/:bookId', component: BookDetailsComponent },
  { path: 'cart', component: CartListingComponent },
  { path: 'cart/:bookId', component: CartComponent },
  { path: 'order', component: OrderListingComponent },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
