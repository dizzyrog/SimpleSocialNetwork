import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from 'src/app/user/User';
import { UserService } from 'src/app/user/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService, private router:Router, private fb: FormBuilder) { }

  user$:Observable<User>
  user:User
  profileFormModel = this.fb.group({
    firstName: [''],
    lastName: [''],
    age: [''],
    email:[''],
    password: [''],
    phoneNumber: [''],
    city:[''],
    country:[''],
    university:[''],
    aboutMe:[''],
});
  ngOnInit() {
    
    this.user$ = this.service.getUserByIdObservable(2);
    this.user$.subscribe(x=> {this.user = x;} );
  }

  onSubmit(user:any) {
    this.service.updateUser(user).subscribe(
      (res: any) => {
          this.profileFormModel.reset();
          this.toastr.success('Information has been updated!');
          this.router.navigateByUrl('');
      //  else {
      //     res.errors.forEach(element => {
      //       switch (element.code) {
      //         case 'DuplicateUserName':
      //           this.toastr.error('Username is already taken','Registration failed.');
      //           break;

      //         default:
      //         this.toastr.error(element.description,'Registration failed.');
      //           break;
      //       }
      //     });
      //   }
      },
      err => {
        console.log(err);
      }
    );
  }

}