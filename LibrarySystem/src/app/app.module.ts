import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DatabaseAccessServiceService } from 'database-access-service.service';
import { LoginComponent } from 'login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatSidenavModule} from '@angular/material/sidenav';
import { FormBuilder,ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import { MainPageComponentComponent } from 'main-page-component/main-page-component.component';
import { BooksComponentComponent } from 'books-component/books-component.component';
import { BookDetailsComponentComponent } from 'book-details-component/book-details-component.component';



@NgModule({
  declarations: [					
    AppComponent,
    LoginComponent,
      MainPageComponentComponent,
      BooksComponentComponent,
      BookDetailsComponentComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    HttpClientModule,
    ReactiveFormsModule,
    

    BrowserModule,
  AppRoutingModule,
  BrowserAnimationsModule,
  FormsModule,
  MatToolbarModule,
  MatInputModule,
  MatCardModule,
  MatMenuModule,
  MatIconModule,
  MatButtonModule,
  MatTableModule,
  MatSlideToggleModule,
  MatSelectModule,
  MatOptionModule,
  MatRadioModule
  ],
  providers: [DatabaseAccessServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
