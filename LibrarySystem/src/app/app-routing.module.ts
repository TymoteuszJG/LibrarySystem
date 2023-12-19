import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBorrowerComponent } from 'add-borrower/add-borrower.component';
import { AddStaffcomponentComponent } from 'add-staffcomponent/add-staffcomponent.component';
import { AuthGuard } from 'auth/auth.guard';
import { AuthorsComponentComponent } from 'authors-component/authors-component.component';
import { BookDetailsComponentComponent } from 'book-details-component/book-details-component.component';
import { BooksComponentComponent } from 'books-component/books-component.component';
import { BorrowersComponentComponent } from 'borrowers-component/borrowers-component.component';
import { LendedComponentComponent } from 'lended-component/lended-component.component';
import { LoginComponent } from 'login/login.component';
import { MainPageComponentComponent } from 'main-page-component/main-page-component.component';
import { StaffComponentComponent } from 'staff-component/staff-component.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'main', component: MainPageComponentComponent,canActivate:[AuthGuard]},
  {path: 'books', component:BooksComponentComponent,canActivate:[AuthGuard]},
  {path: 'books/:id', component:BooksComponentComponent,canActivate:[AuthGuard]},
  { path: 'booksDetails/:id', component: BookDetailsComponentComponent ,canActivate:[AuthGuard]},
  { path: 'staff', component: StaffComponentComponent ,canActivate:[AuthGuard]},
  {path:'authors', component:AuthorsComponentComponent,canActivate:[AuthGuard]},
  {path:'addStaff', component: AddStaffcomponentComponent, canActivate:[AuthGuard]},
  {path: 'addBorrower', component:AddBorrowerComponent, canActivate:[AuthGuard]},
  {path: 'borrowers', component:BorrowersComponentComponent, canActivate:[AuthGuard]},
  {path: 'borrowers/:id', component:BorrowersComponentComponent, canActivate:[AuthGuard]},
  {path: 'lended/:id', component:LendedComponentComponent, canActivate:[AuthGuard]}

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
