import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { AuthorsInterface } from 'app/authors-interface';
import { DatabaseAccessServiceService } from 'database-access-service.service';

@Component({
  selector: 'app-authors-component',
  templateUrl: './authors-component.component.html',
  styleUrls: ['./authors-component.component.css']
})
export class AuthorsComponentComponent implements OnInit {

  AllAuthors:AuthorsInterface[] = [];

  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService) { }

  ngOnInit():void {
    this.service.GetAuthors().subscribe(resp =>{
      this.AllAuthors = resp;
      console.log(this.AllAuthors)
    });


  }

  goToDetailsPage(bookId: number): void {
    // Navigate to the details page with the selected book ID
    this.router.navigate(['/books', bookId]);
  }

}
