export class StaffClass {
    login: string;
    admin: boolean;
    password: string;
  
    constructor(login: string, admin: boolean, password: string) {
      this.login = login;
      this.admin = admin;
      this.password = password;
    }
}
