import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorListingComponent } from './author-listing/author-listing.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BookListingComponent } from './book-listing/book-listing.component';
import { CartListingComponent } from './cart-listing/cart-listing.component';
import { CartComponent } from './cart/cart.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { BadRequestComponent } from './_errors/bad-request/bad-request.component';
import { NotFoundComponent } from './_errors/not-found/not-found.component';
import { ServerErrorComponent } from './_errors/server-error/server-error.component';

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
  { path: 'server-error', component: ServerErrorComponent },
  { path: 'bad-request', component: BadRequestComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
