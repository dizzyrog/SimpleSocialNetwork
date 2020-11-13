import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Friend } from '../friend';
import { FriendsService } from '../friends.service';

@Component({
  selector: 'app-friends-list',
  templateUrl: './friends-list.component.html',
  styleUrls: ['./friends-list.component.css']
})
export class FriendsListComponent implements OnInit {

  friends$:Observable<Friend[]>
  friends: Friend[];
  constructor( private friendService: FriendsService) { }

  ngOnInit() {
    this.friends$ = this.friendService.getFriendsByUserIdObservable(3);
    this.friends$.subscribe(x=> {this.friends = x;} );
  }

  public editInfo(){
    console.log(" going to edit profile page");
  }

  public chat(){
    console.log(" going to chat page");
  }
}
