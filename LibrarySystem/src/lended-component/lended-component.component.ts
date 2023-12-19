import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { DatabaseAccessServiceService } from 'database-access-service.service';
import { LendedInterface } from 'lended-interface';

@Component({
  selector: 'app-lended-component',
  templateUrl: './lended-component.component.html',
  styleUrls: ['./lended-component.component.css']
})
export class LendedComponentComponent implements OnInit {

  borrowerId: number | undefined;
  AllLended:LendedInterface[] = [];

  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService) { }

  ngOnInit():void {


    this.route.params.subscribe(params => {
       this.borrowerId = params['id'];

       
       this.service.GetLendedByBorrowerId(params['id']).subscribe(resp => {
        this.AllLended = resp});

    });

   


  }

  releaseBook(bookId:number,borrowerId: number): void {
    this.service.ReturnBook(bookId,borrowerId).subscribe(
      resp=>
    {
      this.router.navigate(['lended',borrowerId]);
    });
  }

}
