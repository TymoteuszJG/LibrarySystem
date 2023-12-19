import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateService } from 'Authenticate.service';
import { DatabaseAccessServiceService } from 'database-access-service.service';

@Component({
  selector: 'app-staff-component',
  templateUrl: './staff-component.component.html',
  styleUrls: ['./staff-component.component.css']
})
export class StaffComponentComponent implements OnInit {

  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService,  private formBuilder: FormBuilder) { }

  ngOnInit() {
  }
  navigateToAddStaff() {
    this.router.navigate(['/addStaff']);
  }

}
