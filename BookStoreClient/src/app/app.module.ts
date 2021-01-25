import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './account/login/login.component';
import { NavBarComponent } from './nav-bar/nav-bar.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './account/register/register.component';
import { HomeComponent } from './home/home.component';
import { AuthorComponent } from './authors/author/author.component';
import { CommonModule } from '@angular/common';
import { BookListingComponent } from './books/book-listing/book-listing.component';
import { BookDetailsComponent } from './books/book-details/book-details.component';
import { BookComponent } from './books/book/book.component';
import { FooterComponent } from './footer/footer.component';
import { CommentComponent } from './comments/comment/comment.component';
import { CommentListingComponent } from './comments/comment-listing/comment-listing.component';
import { TokenInterceptorService } from './_interceptors/token-interceptor.service';
import { ErrorInterceptorService } from './_interceptors/error-interceptor.service';
import { AuthorListingComponent } from './authors/author-listing/author-listing.component';
import { AuthorBooksComponent } from './authors/author-books/author-books.component';
import { CartListingComponent } from './carts/cart-listing/cart-listing.component';
import { CartComponent } from './carts/cart/cart.component';
import { ProfileComponent } from './account/profile/profile.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NotFoundComponent } from './_errors/not-found/not-found.component';
import { TestErrorsComponent } from './_errors/test-errors/test-errors.component';
import { ToastrModule } from 'ngx-toastr';
import { VoteComponent } from './vote/vote.component';
import { OrderListingComponent } from './order-listing/order-listing.component';
import { NewBookComponent } from './admin/new-book/new-book.component';
import { UpdateKeywordsComponent } from './admin/update-keywords/update-keywords.component';
import { KeywordListingComponent } from './admin/keyword-listing/keyword-listing.component';
import { UpdateBookComponent } from './admin/update-book/update-book.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavBarComponent,
    RegisterComponent,
    HomeComponent,
    AuthorComponent,
    BookComponent,
    BookDetailsComponent,
    BookListingComponent,
    FooterComponent,
    CommentComponent,
    CommentListingComponent,
    AuthorListingComponent,
    AuthorBooksComponent,
    CartListingComponent,
    CartComponent,
    ProfileComponent,
    NotFoundComponent,
    TestErrorsComponent,
    VoteComponent,
    OrderListingComponent,
    NewBookComponent,
    UpdateKeywordsComponent,
    KeywordListingComponent,
    UpdateBookComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
