import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { BorrowerInterface } from 'borrower-interface';
import { DatabaseAccessServiceService } from 'database-access-service.service';

@Component({
  selector: 'app-borrowers-component',
  templateUrl: './borrowers-component.component.html',
  styleUrls: ['./borrowers-component.component.css']
})
export class BorrowersComponentComponent implements OnInit {
  bookId: number =0;
  AllBorrowers:BorrowerInterface[] = [];

  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService) { }

  ngOnInit():void {

    this.service.GetAllBorrowers().subscribe(resp => {
      this.AllBorrowers = resp});
    this.route.params.subscribe(params => {
      const booksId = params['id'];
      if(booksId){
        console.log(booksId)
        this.bookId =booksId;
      }
  
    });

  }
  goToDetailsPage(borrowerId: number): void {
    if (this.bookId!=0) {
      this.service.ReserveBook(this.bookId,borrowerId).subscribe(
        resp=>
      {
        this.router.navigate(['lended',borrowerId]);
      }
      );
      console.log( this.service.ReserveBook(this.bookId,borrowerId))
      console.log("Doing it?")
      console.log(borrowerId + "" + this.bookId)
      
    } else {
      console.log(this.bookId)
      this.router.navigate(['lended',borrowerId]);

      
    }
  }

}
