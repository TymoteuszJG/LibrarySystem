import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {
  isLoggedIn = false;
  userId = 0;

constructor() { }
isAuthenticated(){
  return this.isLoggedIn;
}
succesfulLogIn(userId: number){
  this.isLoggedIn = true;
  this.userId = userId;
}
getUserId(){
  return this.userId;
}

}
 