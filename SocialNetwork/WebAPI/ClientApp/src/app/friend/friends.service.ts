import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { inject } from '@angular/core/testing';
import { Friend } from './friend';

@Injectable({
  providedIn: 'root'
})
export class FriendsService {

  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl:string) { }

  getFriendsByUserIdObservable (id: number){
return this.http.get<Friend[]>(this.baseUrl+'api/friends/'+id);
  }
}
