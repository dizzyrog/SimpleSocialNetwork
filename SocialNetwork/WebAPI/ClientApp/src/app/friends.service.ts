import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { User } from './user/User';

@Injectable({
  providedIn: 'root'
})
export class FriendsService {
constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }




  getFriendsByUserIdObservable (id: number){
    return this.http.get<User[]>(this.baseUrl+'api/friends/'+id);
  }

  getUsersObservable (){
    return this.http.get<User[]>(this.baseUrl+'api/users');
  }
}
