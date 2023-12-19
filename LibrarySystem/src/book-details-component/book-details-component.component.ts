/*import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { DatabaseAccessServiceService } from 'database-access-service.service';
import { SignalRService } from 'signalR.service';

@Component({
  selector: 'app-book-details-component',
  templateUrl: './book-details-component.component.html',
  styleUrls: ['./book-details-component.component.css']
})
export class BookDetailsComponentComponent implements OnInit {
  bookId = 1;
  success = false;

  constructor(
    private route: ActivatedRoute,
    private service: DatabaseAccessServiceService,
    private authService: AuthenticateService,
    private router: Router,
    private signalRService: SignalRService
  ) { }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.bookId = params['id'];
    });

    this.signalRService.startConnection().then(() => {
      this.signalRService.sendRequest(this.authService.getUserId(), this.bookId);
    });

    this.signalRService.responseReceived.subscribe(response => {
      const isOnComponent = response.some((clientResponse: any) => clientResponse.isOnComponent);

      if (isOnComponent) {
        console.log('At least one other user is on the same component. Routing back...');
        this.router.navigate(['/']); // Change the route as needed
      } else {
        console.log('No other users on the same component.');
      }
    });
  }
  isOnSameBook(requestedBookId: number): boolean {

    const currentBookId =  this.bookId.toString()
    return requestedBookId.toString() === currentBookId;
  }

  lockBook(): void {
    this.service.lockBook(this.bookId, this.authService.getUserId()).subscribe(
      locked => {
        if (locked) {
          this.success = true;
          console.log('Book is locked. Showing details...');
        } else {
          console.log('Book is already locked by another user.');
        }
      },
      error => {
        console.error('Error locking the book:', error);
      }
    );
  }

  ngOnDestroy(): void {
    if (this.success) {
      this.service.releaseBook(this.bookId).subscribe(
        () => {
          console.log('Lock released.');
        },
        error => {
          console.error('Error releasing the lock:', error);
        }
      );
    }
  }
}*/
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { DatabaseAccessServiceService } from 'database-access-service.service';
import { SignalRService } from 'signalR.service';
import { BooksClass } from 'books-class';

@Component({
  selector: 'app-book-details-component',
  templateUrl: './book-details-component.component.html',
  styleUrls: ['./book-details-component.component.css']
})
export class BookDetailsComponentComponent implements OnInit {
  bookId = 1;
  success = false;
  dataObject!: BooksClass ;

  constructor(
    private route: ActivatedRoute,
    private service: DatabaseAccessServiceService,
    private authService: AuthenticateService,
    private router: Router,
    private signalRService: SignalRService
  ) { }
   
  ngOnInit(): void {
    this.route.params.subscribe(async (params) => {
      this.bookId = params['id']
      this.service.GetBookById(this.bookId).subscribe(books => {
        this.dataObject = books;
      });
      const hasMatchingBookId = await this.signalRService.sendRequest(this.bookId.toString());
      await(5000);
      console.log("temp")
      console.log(this.signalRService.responseResult)
      console.log(hasMatchingBookId)
      if (hasMatchingBookId) {
        this.signalRService.responseResult= false;
        this.router.navigate(['/books']); 
      }
      this.signalRService.responseResult = false;
    });
  }
  navigateToPage():void{
    this.router.navigate(['borrowers',this.bookId]);
  }


  ngOnDestroy(): void {
    if (this.success) {
      this.service.releaseBook(this.bookId).subscribe(
        () => {
          console.log('Lock released.');
        },
        error => {
          console.error('Error releasing the lock:', error);
        }
      );
    }
  }
}