import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavBarComponent } from './nav-bar/nav-bar.component'
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { AuthorComponent } from './author/author.component';
import { CommonModule } from '@angular/common';
import { BookListingComponent } from './book-listing/book-listing.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BookComponent } from './book/book.component';
import { FooterComponent } from './footer/footer.component';
import { CommentComponent } from './comment/comment.component';
import { CommentListingComponent } from './comment-listing/comment-listing.component';
import { TokenInterceptorService } from './_interceptors/token-interceptor.service';
import { ErrorInterceptorService } from './_interceptors/error-interceptor.service';

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
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
