import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/user/User';
import { UserService } from 'src/app/user/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  // form:FormGroup;
  // user: User;
  

  constructor(public service: UserService, private toastr: ToastrService, private router:Router, private fb: FormBuilder) { }

  profileFormModel = this.fb.group({
    firstName: [''],
    lastName: [''],
    age: [''],
    email:[''],
    userName:[''],
    password: [''],
    phoneNumber: [''],
    city:[''],
    country:[''],
    university:[''],
    aboutMe:[''],
});
  ngOnInit() {
    this.profileFormModel.reset();
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


  
// ngOnInit() {
//   this.form = new FormGroup({
//     firstName: new FormControl(),
//     lastName: new FormControl(),
//     age: new FormControl(),
//     email:new FormControl(),
//     userName:new FormControl(),
//     password: new FormControl(),
//     phoneNumber: new FormControl(),
//     city:new FormControl(),
//     country:new FormControl(),
//     university:new FormControl(),
//     aboutMe:new FormControl(),
//     })
// }