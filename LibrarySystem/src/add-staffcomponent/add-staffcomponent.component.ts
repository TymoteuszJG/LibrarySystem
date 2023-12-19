import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DatabaseAccessServiceService } from 'database-access-service.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthenticateService } from 'Authenticate.service';
import * as CryptoJS from 'crypto-js';
import { StaffClass } from 'staff-class';
@Component({
  selector: 'app-add-staffcomponent',
  templateUrl: './add-staffcomponent.component.html',
  styleUrls: ['./add-staffcomponent.component.css']
})
export class AddStaffcomponentComponent implements OnInit {
  hide = true;
  LoginForm = new FormGroup({
    registry_no: new FormControl('',Validators.required),
    password: new FormControl('')
   })
   error:boolean = false;
  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService,  private formBuilder: FormBuilder) { }
  onSubmit(): void {
    const userlogin = this.LoginForm.value.registry_no as string;
    const userPassword = CryptoJS.SHA256(this.LoginForm.value.password as string).toString(CryptoJS.enc.Hex);
   //let staff :StaffInterface =new StaffInterface(userlogin,userPassword,false);
   const staff:StaffClass = new StaffClass (userlogin,false,userPassword);
   
   
    this.service.AddStaff(staff).subscribe(resp =>{
      if (resp) {
        
        
        this.router.navigate(['/main']);
      } 
      else {
        this.error=true;
      }
      
  } 

    );
  }
  ngOnInit() {
  }

}

/*

export class LoginComponent implements OnInit {
  hide = true;
  LoginForm = new FormGroup({
    registry_no: new FormControl('',Validators.required),
    password: new FormControl('')
   })
   error:boolean = false;
  constructor(private service: DatabaseAccessServiceService,private route: ActivatedRoute,private router: Router, private authService: AuthenticateService,  private formBuilder: FormBuilder) { }
  onSubmit(): void {
    const userlogin = this.LoginForm.value.registry_no as string;
    const userPassword = CryptoJS.SHA256(this.LoginForm.value.password as string).toString(CryptoJS.enc.Hex);
    this.service.GetStaffId(userlogin, userPassword).subscribe(resp =>{
      if (resp != 0) {
        const userId = resp
        this.authService.succesfulLogIn(userId)
        this.router.navigate(['/main']);
      } 
      else {
        this.error=true;
      }
      
  } 

    );
  }
  ngOnInit() {
  }

}*/