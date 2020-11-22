import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FriendsService } from 'src/app/friend/friends.service';
import { User } from 'src/app/user/User';

@Component({
  selector: 'app-friends-list',
  templateUrl: './friends-list.component.html',
  styleUrls: ['./friends-list.component.css']
})
export class FriendsListComponent implements OnInit {
  friends$:Observable<User[]>
  friends: User[];

  constructor(private router: Router, private service: FriendsService) { }

  ngOnInit() {

    this.friends$ = this.service.getFriendsByUserIdObservable();
    this.friends$.subscribe(x=> {this.friends = x;} );

  }

  public editInfo(){
    console.log("going to view profile page");
  }

  public chat(){
    console.log(" going to chat page");
  }
}
