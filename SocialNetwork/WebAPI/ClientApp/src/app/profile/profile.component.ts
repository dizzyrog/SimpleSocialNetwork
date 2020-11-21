import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../user/User';
import { UserService } from '../user/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './profile.component.html',
  //styleUrls: ['./home.component.css']
})
export class ProfileComponent implements OnInit {
  user$:Observable<User>
  user: User;
  

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {

    this.user$ = this.service.getUserByIdObservable(2);
    this.user$.subscribe(x=> {this.user = x;} );
   

  }
   
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
