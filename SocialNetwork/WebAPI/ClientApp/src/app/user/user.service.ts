import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User} from './User';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getUserByIdObservable (id: number){
  return this.http.get<User>(this.baseUrl+'api/users/'+id);
    }

    getUsersObservable (){
      return this.http.get<User[]>(this.baseUrl+'api/users');
      }
  

  RegistrateUser(model:User){
    return this.http.post(this.baseUrl + 'api/user/register', model);
  }

  login(model: User){
    return this.http.post(this.baseUrl + 'api/user/login', model);
  }

  getUserProfile(){
    return this.http.get(this.baseUrl + 'api/UserProfile');
  }

  // get(medium: string) {
  //   const getOptions = {
  //     params: { medium }
  //   };
  //   return this.http.get<MediaItemsResponse>('mediaitems', getOptions)
  //     .pipe(
  //       map((response: MediaItemsResponse) => {
  //         return response.mediaItems;
  //       })
  //     );
  // }
  
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
