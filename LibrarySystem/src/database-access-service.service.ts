import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BooksClass } from 'books-class';
import { AuthorsInterface } from 'app/authors-interface';
import { StaffClass } from 'staff-class';
import { BorrowerInterface } from 'borrower-interface';
import { LendedInterface } from 'lended-interface';


@Injectable()
export class DatabaseAccessServiceService {
    readonly databaseAccesssURL = "https://localhost:7255";
constructor(private http:HttpClient) { }
lockBook(bookId: number, userId: number): Observable<boolean> {
  //const url = `${this.databaseAccesssURL}` + `/lock`;
  console.log(this.http.post<boolean>(this.databaseAccesssURL + `/lock`, { bookId, userId }));
  return this.http.post<boolean>(this.databaseAccesssURL + `/lock`, { bookId, userId });
}

releaseBook(bookId: number): Observable<void> {
  const url = `${this.databaseAccesssURL}/release`;
  return this.http.post<void>(url, { bookId });
}
GetAuthors(): Observable<AuthorsInterface[]>
{
  return this.http.get<any>(this.databaseAccesssURL + `/GetAuthors`);
}
GetBooksByAuthors(authorId:number):Observable<BooksClass[]>
{
  return this.http.get<BooksClass[]>(this.databaseAccesssURL + `/GetBookByAuthors` + `?authorId=${authorId}`);
}
GetStaffId(login: string, password: string): Observable<number>
{
  return this.http.get<number>(this.databaseAccesssURL + `/GetStaffId` +`?login=${login}` + `&password=${password}`);
}
GetAllBookss():Observable<BooksClass[]>
{
  return this.http.get<BooksClass[]>(this.databaseAccesssURL + `/GetAllBooks` );
}
GetBookById(bookId:number):Observable<BooksClass>
{
  return this.http.get<BooksClass>(this.databaseAccesssURL + `/GetBookById`+`?bookId=${bookId}` );
}
AddStaff(staff:StaffClass):Observable<Boolean>{

return this.http.get<Boolean>(this.databaseAccesssURL + `/AddStaff`+`?Login=${staff.login}` +`&Admin=${staff.admin}`+`&Password=${staff.password}`);
}

GetAllBorrowers():Observable<BorrowerInterface[]>
{
  return this.http.get<BorrowerInterface[]>(this.databaseAccesssURL + `/GetAllBorrowers` );
}
AddBorrower(borrower:BorrowerInterface):Observable<BorrowerInterface>{

  return this.http.get<BorrowerInterface>(this.databaseAccesssURL + `/AddBorrower`+`?BorrowersId=${borrower.borrowersId}` +`&Name=${borrower.name}`+`&Surname=${borrower.surname}`+`&ContactNumber=${borrower.contactNumber}`+`&Email=${borrower.email}`);
  }
GetLendedByBorrowerId(borrowerId:number):Observable<LendedInterface[]>{
  return this.http.get<LendedInterface[]>(this.databaseAccesssURL + `/GetLendedByBorrowerId`+`?borrowerId=${borrowerId}`);

}
ReserveBook(bookId:number, borrowerId:number):Observable<BooksClass>{
  console.log(this.databaseAccesssURL + `/ReserveBook`+`?bookId=${bookId}` + `&borrowerId=${borrowerId}` )
  return this.http.get<BooksClass>(this.databaseAccesssURL + `/ReserveBook`+`?bookId=${bookId}` + `&borrowerId=${borrowerId}` );
}
 
ReturnBook(bookId:number, borrowerId:number):Observable<BooksClass>{
  return this.http.get<BooksClass>(this.databaseAccesssURL + `/ReturnBook`+`?bookId=${bookId}` + `&borrowerId=${borrowerId}` );

  
}
  

}
