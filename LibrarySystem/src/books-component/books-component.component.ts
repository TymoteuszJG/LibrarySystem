import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { BooksClass } from 'books-class';
import { DatabaseAccessServiceService } from 'database-access-service.service';

@Component({
  selector: 'app-books-component',
  templateUrl: './books-component.component.html',
  styleUrls: ['./books-component.component.css']
})
export class BooksComponentComponent implements OnInit {
  AllBooks:BooksClass[] = [];

  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService) { }

  ngOnInit():void {
    this.service.GetAllBookss().subscribe(resp =>{
      this.AllBooks = resp;
      console.log(this.AllBooks)
    });


  }

  goToDetailsPage(bookId: number): void {
    // Navigate to the details page with the selected book ID
    this.router.navigate(['/books', bookId]);
  }
}

    
  