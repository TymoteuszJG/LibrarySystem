import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BooksClass } from 'books-class';


@Injectable()
export class DatabaseAccessServiceService {
    readonly databaseAccesssURL = "https://localhost:7255";
constructor(private http:HttpClient) { }
GetAuthors(): Observable<any[]>
{
  return this.http.get<any>(this.databaseAccesssURL + `/GetAuthors`);
}
GetStaffId(login: string, password: string): Observable<number>
{
  return this.http.get<number>(this.databaseAccesssURL + `/GetStaffId` +`?login=${login}` + `&password=${password}`);
}
GetAllBookss():Observable<BooksClass[]>
{
  return this.http.get<BooksClass[]>(this.databaseAccesssURL + `/GetAllBooks` );
}
}
