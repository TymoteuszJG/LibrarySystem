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

    this.route.params.subscribe(params => {
      const authorId = params['id'];
  
      if (authorId) {
        this.service.GetBooksByAuthors(authorId).subscribe(books => {
          this.AllBooks = books;
          console.log(this.AllBooks);
        });
      } else {
        this.service.GetAllBookss().subscribe(resp => {
          this.AllBooks = resp;
          console.log(this.AllBooks);
        });
      }
    });
   


  }

  goToDetailsPage(bookId: number): void {
    this.router.navigate(['/booksDetails', bookId]);
  }
}

    
  