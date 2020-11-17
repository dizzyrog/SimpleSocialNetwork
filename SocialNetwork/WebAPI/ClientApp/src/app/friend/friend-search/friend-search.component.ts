import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/user/User';
import { UserService } from 'src/app/user/user.service';

@Component({
  selector: 'app-friend-search',
  templateUrl: './friend-search.component.html',
  styleUrls: ['./friend-search.component.css']
})
export class FriendSearchComponent implements OnInit {
  users$:Observable<User[]>
  users: User[];

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {

    this.users$ = this.service.getUsersObservable();
    this.users$.subscribe(x=> {this.users = x;} );
  }

}
