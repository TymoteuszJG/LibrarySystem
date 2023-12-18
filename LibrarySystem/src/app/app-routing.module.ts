import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookDetailsComponentComponent } from 'book-details-component/book-details-component.component';
import { BooksComponentComponent } from 'books-component/books-component.component';
import { LoginComponent } from 'login/login.component';
import { MainPageComponentComponent } from 'main-page-component/main-page-component.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'main', component: MainPageComponentComponent},
  {path: 'books', component:BooksComponentComponent},
  { path: 'books/:id', component: BookDetailsComponentComponent },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
