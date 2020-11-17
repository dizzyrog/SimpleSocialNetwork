import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/user/User';
import { UserService } from 'src/app/user/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  form:FormGroup;
  user: User;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.form = new FormGroup({
      firstName: new FormControl(),
      lastName: new FormControl(),
      age: new FormControl(),
      email:new FormControl(),
      userName:new FormControl(),
      password: new FormControl()
    }

    )
  }
  onSubmit(user) {
    this.service.updateUser(user).subscribe(res => {this.user = res});
    console.log("form submitted");
    // this.service.getUserProfile().subscribe(
    //   res => {
    //     this.userDetails = res;
    //   },
    //   err => {
    //     console.log(err);
      //},
    //);
      
  }
}

  
