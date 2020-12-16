import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorComponent } from './author/author.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BookListingComponent } from './book-listing/book-listing.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'book', component: BookListingComponent },
  { path: 'author', component: AuthorComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'book/:bookId', component: BookDetailsComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
