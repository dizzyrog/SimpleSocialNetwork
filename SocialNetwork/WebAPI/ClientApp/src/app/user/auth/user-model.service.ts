import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { UserModel } from './userModel';

@Injectable({
  providedIn: 'root'
})
export class UserModelService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  RegistrateUser(model:UserModel){
    return this.http.post(this.baseUrl + 'api/account/register', model);
  }

  login(model: UserModel){
    return this.http.post(this.baseUrl + 'api/account/login', model);
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if (userRole == element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}
